using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.BrandDtos;
using OnionApp.WebUI.Dtos.FeatureDtos;
using OnionApp.WebUI.Services.BrandServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController (IBrandService _service): Controller
    {
        public async Task<IActionResult> Index()
        {
            var features = await _service.GetAllAsync();
            return View(features.Data);
        }
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto create)
        {
            await _service.CreateAsync(create);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var features = await _service.GetByIdAsync(id);
            return View(features.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto update)
        {
            await _service.UpdateAsync(update);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
