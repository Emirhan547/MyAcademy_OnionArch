using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.AboutDtos;
using OnionApp.WebUI.Dtos.SocialMediaDtos;
using OnionApp.WebUI.Services.SocialMediaServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController(ISocialMediaService _service) : Controller
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
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto create)
        {
            await _service.CreateAsync(create);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var features = await _service.GetByIdAsync(id);
            return View(features.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto update)
        {
            await _service.UpdateAsync(update);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
