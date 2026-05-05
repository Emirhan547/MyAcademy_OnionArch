namespace OnionApp.WebUI.Dtos.UserInsightDtos
{
    public class RecommendationResultDto
    {
        public string UserId { get; set; } = string.Empty;
        public IReadOnlyCollection<string> SuggestedCarIds { get; set; } = [];
        public string ModelVersion { get; set; } = string.Empty;
        public double ConfidenceScore { get; set; }
    }
}
