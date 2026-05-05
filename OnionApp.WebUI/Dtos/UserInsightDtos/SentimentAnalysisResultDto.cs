namespace OnionApp.WebUI.Dtos.UserInsightDtos
{
    public class SentimentAnalysisResultDto
    {
        public int PositiveCount { get; set; }
        public int NegativeCount { get; set; }
        public int NeutralCount { get; set; }
        public IReadOnlyCollection<string> ImprovementTopics { get; set; } = [];
        public string ModelVersion { get; set; } = string.Empty;
        public DateTime GeneratedAtUtc { get; set; }
    }
}
