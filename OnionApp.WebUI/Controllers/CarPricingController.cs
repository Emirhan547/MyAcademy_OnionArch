using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionApp.WebUI.Dtos.CarPricingDtos;
using OnionApp.WebUI.Services.CarPricingServices;

namespace OnionApp.WebUI.Controllers
{
    public class CarPricingController(ICarPricingService _service) : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";
            var values = await _service.GetCarPricingWithTimePeriod();
            return View(values.Data);
        }

    }
}
