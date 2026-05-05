using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.LocationDtos;
using OnionApp.WebUI.Services.LocationServices;
using System.Net.Http.Headers;

namespace OnionApp.WebUI.Controllers
{
    public class DefaultController(ILocationService _locationService) : Controller
    {
       

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SelectListItem> values2 = new();

            var result = await _locationService.GetAllAsync();

            if (result.IsSuccessful && result.Data != null)
            {
                values2 = result.Data.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            }

            ViewBag.v = values2;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string book_pick_date, string book_off_date, string time_pick, string time_off, string locationID)
        {
            TempData["bookpickdate"] = book_pick_date;
            TempData["bookoffdate"] = book_off_date;
            TempData["timepick"] = time_pick;
            TempData["timeoff"] = time_off;
            TempData["locationID"] = locationID;
            return RedirectToAction("Index", "RentACarList");
        }

    }
}
