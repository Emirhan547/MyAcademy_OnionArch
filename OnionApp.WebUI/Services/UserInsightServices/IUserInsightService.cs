using OnionApp.WebUI.Dtos.UserInsightDtos;

namespace OnionApp.WebUI.Services.UserInsightServices
{
    public interface IUserInsightService
    {
        Task<RecommendationResultDto?> GetRecommendationsAsync(string userId);
        Task<ChurnPredictionResultDto?> GetChurnPredictionAsync(string userId);
        Task<PriceSuggestionResultDto?> GetPriceSuggestionAsync(string city, string carSegment, DateOnly pickupDate, DateOnly returnDate);
        Task<SentimentAnalysisResultDto?> GetSentimentAsync();
        Task<bool> PublishUserEventAsync(UserEventMessageDto dto);
    }
}
