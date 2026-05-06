using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OnionApp.WebUI.Dtos.AiDtos;
using OnionApp.WebUI.Dtos.LocationDtos;
using OnionApp.WebUI.Dtos.ReservationDtos;
using OnionApp.WebUI.Models;
using OnionApp.WebUI.Services.AiServices;
using OnionApp.WebUI.Services.CarServices;
using OnionApp.WebUI.Services.LocationServices;
using OnionApp.WebUI.Services.ReservationServices;
using System.Text;

namespace OnionApp.WebUI.Controllers
{
    public class ReservationController(ILocationService locationService, IReservationService reservationService, IArtificialIntelligenceWebService aiService) : Controller
    {
        
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";

            return View(new ReservationFormViewModel
            {
                Reservation = new() { CarId = id },
                Locations = await GetLocationSelectListAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index(ReservationFormViewModel model, string submitAction)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = submitAction == "ai-check" ? "AI Rezervasyon Ön Kontrol" : "Araç Rezervasyon Formu";
            var dto = model.Reservation;
            var locations = await GetLocationSelectListAsync();

            if (submitAction == "ai-check")
            {
                var aiResult = await aiService.GetReservationAssistantAsync(new ReservationAssistantAiRequestDto
                {
                    PickUpLocation = GetLocationName(locations, dto.PickUpLocationId),
                    DropOffLocation = GetLocationName(locations, dto.DropOffLocationId),
                    PickUpDate = dto.PickUpDate,
                    ReturnDate = dto.ReturnDate,
                    Age = dto.Age,
                    DriverLicenseYear = dto.DriverLicenseYear,
                    TravelNotes = dto.Description
                });

                return View(new ReservationFormViewModel
                {
                    Reservation = dto,
                    Locations = locations,
                    AiResult = aiResult
                });
            }

            var success = await reservationService.CreateAsync(dto);

            if (success)
            {
                return RedirectToAction("Index", "Default");
            }

            return View(new ReservationFormViewModel
            {
                Reservation = dto,
                Locations = locations
            });
        }
        private async Task<List<SelectListItem>> GetLocationSelectListAsync()
        {
            var result = await locationService.GetAllAsync();

            return result.IsSuccessful && result.Data != null
                ? result.Data.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList()
                : new List<SelectListItem>();
        }

        private static string GetLocationName(List<SelectListItem> locations, int locationId)
        {
            return locations.FirstOrDefault(x => x.Value == locationId.ToString())?.Text ?? "Lokasyon seçilmedi";
        }
    }
}
