using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.PricingDtos;
using OnionApp.WebUI.Services.PricingServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PricingController(IPricingService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var pricings = await _service.GetAllAsync();
            return View(pricings.Data);
        }
        public IActionResult CreatePricing ()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePricing (CreatePricingDto create)
        {
            await _service.CreateAsync(create);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePricing (int id)
        {
            var pricing = await _service.GetByIdAsync(id);
            return View(pricing.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePricing(UpdatePricingDto update)
        {
            await _service.UpdateAsync(update);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeletePricing(int id)

        { 
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
