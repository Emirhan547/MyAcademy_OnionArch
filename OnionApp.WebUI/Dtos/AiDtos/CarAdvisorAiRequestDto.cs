namespace OnionApp.WebUI.Dtos.AiDtos
{
    public sealed class CarAdvisorAiRequestDto
    {
        public string TripPurpose { get; set; } = string.Empty;
        public int PassengerCount { get; set; } = 2;
        public decimal? DailyBudget { get; set; }
        public string PreferredFuel { get; set; } = string.Empty;
        public string PreferredTransmission { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
