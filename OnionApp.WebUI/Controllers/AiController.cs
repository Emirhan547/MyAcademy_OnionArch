using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.AiDtos;
using OnionApp.WebUI.Services.AiServices;

namespace OnionApp.WebUI.Controllers
{
    public class AiController(IArtificialIntelligenceWebService aiService) : Controller
    {
        [HttpGet]
        public IActionResult CarAdvisor()
        {
            ViewBag.v1 = "Yapay Zeka";
            ViewBag.v2 = "Araç Danışmanı";
            return View(new CarAdvisorAiRequestDto());
        }

        [HttpPost]
        public async Task<IActionResult> CarAdvisor(CarAdvisorAiRequestDto model)
        {
            ViewBag.v1 = "Yapay Zeka";
            ViewBag.v2 = "Araç Danışmanı";
            ViewBag.AiResult = await aiService.GetCarAdvisorAsync(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult ReservationAssistant()
        {
            ViewBag.v1 = "Yapay Zeka";
            ViewBag.v2 = "Rezervasyon Asistanı";
            return View(new ReservationAssistantAiRequestDto());
        }

        [HttpPost]
        public async Task<IActionResult> ReservationAssistant(ReservationAssistantAiRequestDto model)
        {
            ViewBag.v1 = "Yapay Zeka";
            ViewBag.v2 = "Rezervasyon Asistanı";
            ViewBag.AiResult = await aiService.GetReservationAssistantAsync(model);
            return View(model);
        }
    }
}