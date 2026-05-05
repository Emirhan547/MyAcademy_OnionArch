namespace OnionApp.WebUI.Dtos.UserInsightDtos
{
    public class UserInsightDashboardViewModel
    {
        public string UserId { get; set; } = "demo-user-1";
        public string City { get; set; } = "Istanbul";
        public string CarSegment { get; set; } = "SUV";
        public DateOnly PickupDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly ReturnDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(3));
        public RecommendationResultDto? Recommendation { get; set; }
        public ChurnPredictionResultDto? ChurnPrediction { get; set; }
        public PriceSuggestionResultDto? PriceSuggestion { get; set; }
        public SentimentAnalysisResultDto? Sentiment { get; set; }
        public string? EventStatus { get; set; }
    }
}
