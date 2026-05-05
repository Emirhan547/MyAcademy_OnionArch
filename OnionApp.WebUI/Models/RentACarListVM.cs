using OnionApp.WebUI.Dtos.RentACarDtos;

namespace OnionApp.WebUI.Models
{
    public class RentACarListVM
    {
        public List<FilterRentACarDto> Cars { get; set; } = new();
        public IReadOnlyCollection<string> SuggestedCars { get; set; } = new List<string>();
        public string PriceBand { get; set; } = "";
        public bool Opportunity { get; set; }
        public string Segment { get; set; } = "";
        public string City { get; set; } = "";
        public string UserId { get; set; } = "";
    }
}
