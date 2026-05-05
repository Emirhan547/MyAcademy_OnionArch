using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.AboutDtos;
using OnionApp.WebUI.Dtos.FeatureDtos;
using OnionApp.WebUI.Services.AboutServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController (IAboutService _service): Controller
    {
        public async Task<IActionResult> Index()
        {
            var features = await _service.GetAllAsync();
            return View(features.Data);
        }
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto create)
        {
            await _service.CreateAsync(create);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var features = await _service.GetByIdAsync(id);
            return View(features.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto update)
        {
            await _service.UpdateAsync(update);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
