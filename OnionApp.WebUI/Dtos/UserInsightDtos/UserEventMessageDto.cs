namespace OnionApp.WebUI.Dtos.UserInsightDtos
{
    public class UserEventMessageDto
    {
        public string UserId { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
        public string FeatureName { get; set; } = string.Empty;
        public DateTime OccurredAtUtc { get; set; } = DateTime.UtcNow;
        public string CorrelationId { get; set; } = Guid.NewGuid().ToString("N");
        public Dictionary<string, string>? Metadata { get; set; }
    }
}
