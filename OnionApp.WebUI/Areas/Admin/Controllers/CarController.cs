using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.CarDtos;
using OnionApp.WebUI.Services.BrandServices;
using OnionApp.WebUI.Services.CarFeatureServices;
using OnionApp.WebUI.Services.CarServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController (ICarService _service,IBrandService _brandService,ICarFeatureService _carFeature): Controller
    {
        public async Task<IActionResult> Index()
        {
            var cars=await _service.GetAllAsync();
            return View(cars.Data);
        }
        public async Task<IActionResult> CreateCar()
        {
            var result = await _brandService.GetBrandSelectList();
            ViewBag.BrandValues = result.Data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            await _service.CreateAsync(createCarDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateCar(int id)
        {
            var carResult = await _service.GetByIdAsync(id);
            var brandResult = await _brandService.GetBrandSelectList();

            if (carResult.Data == null)
                return View();

            ViewBag.BrandValues = brandResult.Data;

            return View(carResult.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto update)
        {
            await _service.UpdateAsync(update);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCar(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> CarDetail(int id)
        {
            var result = await _carFeature.GetCarFeaturesByCarId(id);
            return View(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeFeatureToFalse(int id, int carId)
        {
            await _carFeature.ChangeCarFeatureAvailableToFalse(id);
            return RedirectToAction("CarDetail", new { id = carId });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeFeatureToTrue(int id, int carId)
        {
            await _carFeature.ChangeCarFeatureAvailableToTrue(id);
            return RedirectToAction("CarDetail", new { id = carId });
        }
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId()
        {
            var result=await _carFeature.CreateFeatureByCarId();
            return View(result.Data);
        }
    }
}
