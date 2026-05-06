using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AiDtos;
using OnionApp.WebUI.Dtos.CarPricingDtos;

namespace OnionApp.WebUI.Models
{
    public class CarListViewModel
    {
        public List<ResultCarPricingWithCarDto> Cars { get; set; } = new();
        public CarAdvisorAiRequestDto AiRequest { get; set; } = new();
        public BaseResult<AiSuggestionDto>? AiResult { get; set; }
    }
}
