using OnionApp.WebUI.Dtos.UserInsightDtos;

namespace OnionApp.WebUI.Services.UserInsightServices;

public class UserInsightService : IUserInsightService
{
    private readonly HttpClient _client;

    public UserInsightService(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("ApiClient");
    }

    public async Task<RecommendationResultDto?> GetRecommendationsAsync(string userId)
        => await _client.GetFromJsonAsync<RecommendationResultDto>($"userinsights/{userId}/recommendations");
    public async Task<PriceSuggestionResultDto?> GetPriceSuggestionAsync(string city, string carSegment, DateOnly pickupDate, DateOnly returnDate)
        => await _client.GetFromJsonAsync<PriceSuggestionResultDto>($"userinsights/price-suggestion?city={city}&carSegment={carSegment}&pickupDate={pickupDate:yyyy-MM-dd}&returnDate={returnDate:yyyy-MM-dd}");

    public async Task<SentimentAnalysisResultDto?> GetSentimentAsync()
        => await _client.GetFromJsonAsync<SentimentAnalysisResultDto>("userinsights/sentiment");
    public async Task<ChurnPredictionResultDto?> GetChurnPredictionAsync(string userId)
        => await _client.GetFromJsonAsync<ChurnPredictionResultDto>($"userinsights/{userId}/churn");

    public async Task<bool> PublishUserEventAsync(UserEventMessageDto dto)
    {
        var response = await _client.PostAsJsonAsync("userinsights/events", dto);
        return response.IsSuccessStatusCode;
    }
}