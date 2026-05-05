using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OnionApp.WebUI.Dtos.LocationDtos;
using OnionApp.WebUI.Dtos.ReservationDtos;
using OnionApp.WebUI.Models;
using OnionApp.WebUI.Services.LocationServices;
using OnionApp.WebUI.Services.ReservationServices;
using System.Text;

namespace OnionApp.WebUI.Controllers
{
    public class ReservationController(ILocationService _locationService,IReservationService _reservationService) : Controller
    {
        
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";

            var result = await _locationService.GetAllAsync();

            var locations = result.IsSuccessful && result.Data != null
                 ? result.Data.Select(x => new SelectListItem
                 {
                    Text = x.Name,
                    Value = x.Id.ToString()
                 }).ToList()
                : new List<SelectListItem>();

            var model = new ReservationFormViewModel
            {
                Reservation = new() { CarId = id },
                Locations = locations
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ReservationFormViewModel model)
        {
            var dto = model.Reservation;
            var success = await _reservationService.CreateAsync(dto);

            if (success)
                return RedirectToAction("Index", "Default");

            var locationsResult = await _locationService.GetAllAsync();
            var locations = locationsResult.IsSuccessful && locationsResult.Data != null
                ? locationsResult.Data.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList()
                : new List<SelectListItem>();

            return View(new ReservationFormViewModel
            {
                Reservation = dto,
                Locations = locations
            });
        }

    }
}
