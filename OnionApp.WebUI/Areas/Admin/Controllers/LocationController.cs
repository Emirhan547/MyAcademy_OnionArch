using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.AboutDtos;
using OnionApp.WebUI.Dtos.LocationDtos;
using OnionApp.WebUI.Services.LocationServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationController(ILocationService _service) : Controller
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
        public async Task<IActionResult> CreateLocation(CreateLocationDto create)
        {
            await _service.CreateAsync(create);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var features = await _service.GetByIdAsync(id);
            return View(features.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto update)
        {
            await _service.UpdateAsync(update);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
