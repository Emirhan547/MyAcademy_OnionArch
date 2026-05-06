using Microsoft.AspNetCore.Mvc.Rendering;
using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AiDtos;
using OnionApp.WebUI.Dtos.ReservationDtos;

namespace OnionApp.WebUI.Models
{
    public class ReservationFormViewModel
    {
        public CreateReservationDto Reservation { get; init; } = new();
        public List<SelectListItem> Locations { get; init; } = new();
        public BaseResult<AiSuggestionDto>? AiResult { get; init; }
    }
}
