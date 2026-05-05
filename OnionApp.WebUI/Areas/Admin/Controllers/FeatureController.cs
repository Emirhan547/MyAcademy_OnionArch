using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.FeatureDtos;
using OnionApp.WebUI.Services.FeatureServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController (IFeatureService _service): Controller
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
        public async Task<IActionResult> CreateFeature(CreateFeatureDto create)
        {
            await _service.CreateAsync(create);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var features = await _service.GetByIdAsync(id);
            return View(features.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto update)
        {
            await _service.UpdateAsync(update);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
