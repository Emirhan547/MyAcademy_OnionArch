using Microsoft.AspNetCore.Mvc.Rendering;
using OnionApp.WebUI.Dtos.ReservationDtos;

namespace OnionApp.WebUI.Models
{
    public class ReservationFormViewModel
    {
        public CreateReservationDto Reservation { get; init; } = new();
        public List<SelectListItem> Locations { get; init; } = new();
    }
}
