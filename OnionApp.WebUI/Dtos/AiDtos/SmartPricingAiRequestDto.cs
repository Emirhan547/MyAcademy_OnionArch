namespace OnionApp.WebUI.Dtos.AiDtos
{
    public sealed class SmartPricingAiRequestDto
    {
        public string CarType { get; set; } = string.Empty;
        public string Season { get; set; } = "normal";
        public string Location { get; set; } = string.Empty;
        public int Km { get; set; }
        public string Fuel { get; set; } = string.Empty;
        public int HistoricalDemandIndex { get; set; } = 50;
    }
}
