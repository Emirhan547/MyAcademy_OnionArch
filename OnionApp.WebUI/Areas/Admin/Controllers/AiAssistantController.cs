using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.AiDtos;
using OnionApp.WebUI.Services.AiServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AiAssistantController(IArtificialIntelligenceWebService aiService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new AdminContentAiRequestDto());
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminContentAiRequestDto model)
        {
            ViewBag.AiResult = await aiService.GetAdminContentAsync(model);
            return View(model);
        }
    }
}