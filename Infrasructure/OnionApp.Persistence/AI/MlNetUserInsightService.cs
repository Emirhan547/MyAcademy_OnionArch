using Microsoft.Extensions.Options;
using OnionApp.Application.AI.Models;
using OnionApp.Application.AI.Services;

namespace OnionApp.Persistence.AI;

public sealed class MlNetUserInsightService : IRecommendationService, IChurnPredictionService, IPriceSuggestionService, ISentimentAnalysisService
{
    private readonly MlNetOptions _options;

    public MlNetUserInsightService(IOptions<MlNetOptions> options)
    {
        _options = options.Value;
    }

    public Task<RecommendationResult> GetRecommendationsAsync(string userId, CancellationToken cancellationToken = default)
    {
        var recommendations = new[] { "car-12", "car-5", "car-1" };
        var result = new RecommendationResult(userId, recommendations, _options.RecommendationModelVersion, 0.78);
        return Task.FromResult(result);
    }

    public Task<ChurnPredictionResult> PredictAsync(string userId, CancellationToken cancellationToken = default)
    {
        var result = new ChurnPredictionResult(userId, 0.34, "LowRisk", _options.ChurnModelVersion, DateTime.UtcNow);
        return Task.FromResult(result);
    }
    public Task<PriceSuggestionResult> SuggestAsync(string city, string carSegment, DateOnly pickupDate, DateOnly returnDate, CancellationToken cancellationToken = default)
    {
        var totalDays = Math.Max(1, returnDate.DayNumber - pickupDate.DayNumber);
        var demandMultiplier = city.Equals("istanbul", StringComparison.OrdinalIgnoreCase) ? 1.15m : 1.0m;
        var segmentBase = carSegment.Equals("SUV", StringComparison.OrdinalIgnoreCase) ? 2400m : 1700m;
        var minPrice = segmentBase * demandMultiplier;
        var maxPrice = minPrice + (totalDays * 125m);

        var result = new PriceSuggestionResult(city, carSegment, pickupDate, returnDate, minPrice, maxPrice, minPrice < 2000m, _options.RecommendationModelVersion);
        return Task.FromResult(result);
    }

    public Task<SentimentAnalysisResult> AnalyzeAsync(CancellationToken cancellationToken = default)
    {
        var topics = new[] { "Araç temizliği", "Teslim alma hızı", "Fiyat/performans" };
        var result = new SentimentAnalysisResult(128, 34, 19, topics, _options.ChurnModelVersion, DateTime.UtcNow);
        return Task.FromResult(result);
    }
}