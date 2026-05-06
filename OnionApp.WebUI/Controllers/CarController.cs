using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.CarPricingDtos;
using OnionApp.WebUI.Models;
using OnionApp.WebUI.Services.AiServices;
using OnionApp.WebUI.Services.CarPricingServices;

namespace OnionApp.WebUI.Controllers
{
    public class CarController(ICarPricingService service, IArtificialIntelligenceWebService aiService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Araçlarınızı Seçiniz";
            return View(new CarListViewModel
            {
                Cars = await GetCarsAsync()
            });
        }
        [HttpPost]
        public async Task<IActionResult> Index(CarListViewModel model)
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "AI Destekli Araç Seçimi";

            model.Cars = await GetCarsAsync();
            model.AiResult = await aiService.GetCarAdvisorAsync(model.AiRequest);

            return View(model);
        }
        public IActionResult CarDetail(int id)
        {
            ViewBag.v1 = "Araç Detayları";
            ViewBag.v2 = "Aracın Teknik Aksesuar ve Özellikleri";
            return View(new CarDetailViewModel { CarId = id });
        }
        private async Task<List<ResultCarPricingWithCarDto>> GetCarsAsync()
        {
            var cars = await service.GetCarPricingWithCar();
            return cars.Data ?? new List<ResultCarPricingWithCarDto>();
        }
    }
}
