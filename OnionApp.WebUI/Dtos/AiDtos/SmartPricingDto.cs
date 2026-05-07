namespace OnionApp.WebUI.Dtos.AiDtos
{
    public sealed class SmartPricingDto
    {
        public string Title { get; set; } = string.Empty;
        public decimal SuggestedDailyPrice { get; set; }
        public string Currency { get; set; } = "TRY";
        public string Summary { get; set; } = string.Empty;
        public List<string> PriceFactors { get; set; } = [];
        public DateTime GeneratedAtUtc { get; set; }
    }
}
