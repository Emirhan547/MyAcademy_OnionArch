namespace OnionApp.WebUI.Dtos.UserInsightDtos
{
    public class PriceSuggestionResultDto
    {
        public string City { get; set; } = string.Empty;
        public string CarSegment { get; set; } = string.Empty;
        public DateOnly PickupDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public decimal SuggestedMinPrice { get; set; }
        public decimal SuggestedMaxPrice { get; set; }
        public bool IsOpportunity { get; set; }
        public string ModelVersion { get; set; } = string.Empty;
    }
}
