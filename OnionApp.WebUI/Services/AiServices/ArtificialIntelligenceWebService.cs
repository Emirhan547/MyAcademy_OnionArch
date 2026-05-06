using System.Net.Http.Json;
using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AiDtos;

namespace OnionApp.WebUI.Services.AiServices
{
    public sealed class ArtificialIntelligenceWebService(IHttpClientFactory factory) : IArtificialIntelligenceWebService
    {
        private readonly HttpClient _client = factory.CreateClient("ApiClient");

        public async Task<BaseResult<AiSuggestionDto>> GetCarAdvisorAsync(CarAdvisorAiRequestDto request)
        {
            return await PostAsync<CarAdvisorAiRequestDto>("ArtificialIntelligence/car-advisor", request);
        }

        public async Task<BaseResult<AiSuggestionDto>> GetReservationAssistantAsync(ReservationAssistantAiRequestDto request)
        {
            return await PostAsync<ReservationAssistantAiRequestDto>("ArtificialIntelligence/reservation-assistant", request);
        }

        public async Task<BaseResult<AiSuggestionDto>> GetAdminContentAsync(AdminContentAiRequestDto request)
        {
            return await PostAsync<AdminContentAiRequestDto>("ArtificialIntelligence/admin-content", request);
        }

        private async Task<BaseResult<AiSuggestionDto>> PostAsync<TRequest>(string url, TRequest request)
        {
            var response = await _client.PostAsJsonAsync(url, request);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<AiSuggestionDto>>();
            return result ?? new BaseResult<AiSuggestionDto>
            {
                Errors = new() { new Error { ErrorMessage = "AI servisi yanıtı okunamadı." } }
            };
        }
    }
}