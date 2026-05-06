namespace OnionApp.WebUI.Dtos.AiDtos
{
    public sealed class SmartCarRankingAiRequestDto
    {
        public int LocationId { get; set; }
        public string City { get; set; } = string.Empty;
        public string Segment { get; set; } = string.Empty;
        public string TripPurpose { get; set; } = string.Empty;
        public int PassengerCount { get; set; } = 2;
        public decimal? DailyBudget { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
