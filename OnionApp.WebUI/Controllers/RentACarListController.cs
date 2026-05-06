using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionApp.WebUI.Dtos.AiDtos;
using OnionApp.WebUI.Dtos.RentACarDtos;
using OnionApp.WebUI.Models;
using OnionApp.WebUI.Services.AiServices;
using OnionApp.WebUI.Services.RentACarServices;
using System.Net.Http;
using System.Text;


namespace UdemyCarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IRentACarService _rentACarService;
        private readonly IArtificialIntelligenceWebService _aiService;
        public RentACarListController(IRentACarService rentACarService, IArtificialIntelligenceWebService aiService)
        {
            _rentACarService = rentACarService;
            _aiService = aiService;


        }

        public async Task<IActionResult> Index(int id, string userId = "demo-user-1", string city = "Istanbul", string carSegment = "SUV", string tripPurpose = "Şehir içi ve kısa yol", int passengerCount = 2, decimal? dailyBudget = null)
        {
            var locationID = TempData["locationID"];

            if (locationID != null)
            {
                id = int.Parse(locationID.ToString()!);
            }

            if (id <= 0)
            {
                return View(new RentACarListVM());
            }

            var values = await _rentACarService.GetAvailableCarsAsync(id);
            var cars = values ?? new List<FilterRentACarDto>();
            var aiRequest = new SmartCarRankingAiRequestDto
            {
                LocationId = id,
                City = city,
                Segment = carSegment,
                TripPurpose = tripPurpose,
                PassengerCount = passengerCount,
                DailyBudget = dailyBudget
            };
            var aiResult = cars.Any() ? await _aiService.GetSmartCarRankingAsync(aiRequest) : null;


            var vm = new RentACarListVM
            {
                Cars = cars,
                SuggestedCars = aiResult?.Data?.Suggestions ?? new List<string>(),
                PriceBand = dailyBudget.HasValue ? $"Günlük bütçe hedefi: ₺{dailyBudget.Value:N0}" : "Bütçe belirtilmedi",
                Opportunity = aiResult?.Data?.Suggestions.Any(x => x.Contains("fırsat", StringComparison.OrdinalIgnoreCase) || x.Contains("ekonomik", StringComparison.OrdinalIgnoreCase)) == true,
                Segment = carSegment,
                City = city,
                UserId = userId,
                LocationId = id,
                AiRequest = aiRequest,
                AiResult = aiResult
            };

            return View(vm);
        }
    }
}