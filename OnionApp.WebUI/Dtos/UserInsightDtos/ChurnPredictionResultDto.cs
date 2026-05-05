namespace OnionApp.WebUI.Dtos.UserInsightDtos
{
    public class ChurnPredictionResultDto
    {
        public string UserId { get; set; } = string.Empty;
        public double RiskScore { get; set; }
        public string Segment { get; set; } = string.Empty;
        public string ModelVersion { get; set; } = string.Empty;
        public DateTime GeneratedAtUtc { get; set; }
    }
}
