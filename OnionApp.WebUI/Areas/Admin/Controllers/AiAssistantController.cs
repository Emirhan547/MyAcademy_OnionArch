using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.AiDtos;
using OnionApp.WebUI.Services.AiServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AiAssistantController(IArtificialIntelligenceWebService aiService) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> SmartPricing(SmartPricingAiRequestDto model)
        {
            ViewBag.SmartPricingResult = await aiService.GetSmartPricingAsync(model);
            ViewBag.SmartPricingRequest = model;
            return View("Index", new AdminContentAiRequestDto());
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.SmartPricingRequest = new SmartPricingAiRequestDto();
            return View(new AdminContentAiRequestDto());
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminContentAiRequestDto model)
        {
            ViewBag.AiResult = await aiService.GetAdminContentAsync(model);
            ViewBag.SmartPricingRequest = new SmartPricingAiRequestDto();
            return View(model);
        }
    }
}