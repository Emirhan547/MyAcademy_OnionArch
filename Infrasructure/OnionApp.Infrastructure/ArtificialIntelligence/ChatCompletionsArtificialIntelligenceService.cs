
using Microsoft.Extensions.Options;
using OnionApp.Application.Contracts.AI;
using OnionApp.Application.Features.Results;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnionApp.Infrastructure.ArtificialIntelligence
{
    public sealed class ChatCompletionsArtificialIntelligenceService(HttpClient httpClient, IOptions<AiSettings> options) : IArtificialIntelligenceService
    {
        private readonly AiSettings _settings = options.Value;

        public async Task<AiSuggestionResult> GenerateSuggestionAsync(AiPromptRequest request, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(_settings.ApiKey))
            {
                return CreateFallbackResult(request, "LocalFallback");
            }

            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, _settings.Endpoint);
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _settings.ApiKey);
            httpRequest.Content = JsonContent.Create(new
            {
                model = _settings.Model,
                temperature = _settings.Temperature,
                max_tokens = _settings.MaxTokens,
                messages = new[]
                {
                    new { role = "system", content = request.SystemPrompt },
                    new { role = "user", content = request.UserPrompt }
                }
            });

            using var response = await httpClient.SendAsync(httpRequest, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return CreateFallbackResult(request, $"LocalFallback ({(int)response.StatusCode})");
            }

            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
            using var document = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);
            var content = document.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            if (string.IsNullOrWhiteSpace(content))
            {
                return CreateFallbackResult(request, "LocalFallback (empty AI response)");
            }

            return new AiSuggestionResult
            {
                Title = request.FallbackTitle,
                Summary = NormalizeAiContent(content),
                Suggestions = SplitSuggestions(content),
                Source = _settings.Provider,
                GeneratedAtUtc = DateTime.UtcNow
            };
        }
        private static string NormalizeAiContent(string content)
        {
            var sanitized = content
                .Replace("#*", string.Empty, StringComparison.Ordinal)
                .Replace("*#", string.Empty, StringComparison.Ordinal);

            var lines = sanitized
                .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(line => line.TrimStart('#', ' '))
                .Where(line => !string.IsNullOrWhiteSpace(line));

            return string.Join(Environment.NewLine, lines).Trim();
        }
        private static AiSuggestionResult CreateFallbackResult(AiPromptRequest request, string source)
        {
            return new AiSuggestionResult
            {
                Title = request.FallbackTitle,
                Summary = "AI servis anahtarı tanımlı olmadığı için Clean Architecture akışını bozmadan yerel öneri motoru çalıştırıldı.",
                Suggestions = request.FallbackSuggestions.ToList(),
                Source = source,
                GeneratedAtUtc = DateTime.UtcNow
            };
        }

        private static List<string> SplitSuggestions(string content)
        {
            var normalizedContent = NormalizeAiContent(content);

            return normalizedContent.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Where(x => x.StartsWith("-") || x.StartsWith("•") || char.IsDigit(x[0]))
                .Select(x => x.TrimStart('-', '•', ' ', '\t'))
                .Take(8)
                .DefaultIfEmpty(content.Length > 280 ? content[..280] + "..." : content)
                .ToList();
        }
    }
}
