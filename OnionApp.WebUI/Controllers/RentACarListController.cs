using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionApp.WebUI.Dtos.RentACarDtos;
using OnionApp.WebUI.Models;
using OnionApp.WebUI.Services.RentACarServices;
using OnionApp.WebUI.Services.UserInsightServices;
using System.Net.Http;
using System.Text;


namespace UdemyCarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IRentACarService _rentACarService;
        private readonly IUserInsightService _userInsightService;
        public RentACarListController(IRentACarService rentACarService, IUserInsightService userInsightService)
        {
            _rentACarService = rentACarService;
            _userInsightService = userInsightService;
        }

        public async Task<IActionResult> Index(int id, string userId = "demo-user-1", string city = "Istanbul", string carSegment = "SUV")
        {
            var locationID = TempData["locationID"];

            if (locationID == null)
                return View(new RentACarListVM());

            id = int.Parse(locationID.ToString()!);

            var values = await _rentACarService.GetAvailableCarsAsync(id);

            var pickupDate = DateOnly.FromDateTime(DateTime.UtcNow);
            var returnDate = pickupDate.AddDays(3);

            var recommendation = await _userInsightService.GetRecommendationsAsync(userId);
            var priceSuggestion = await _userInsightService.GetPriceSuggestionAsync(city, carSegment, pickupDate, returnDate);

            var vm = new RentACarListVM
            {
                Cars = values ?? new List<FilterRentACarDto>(),
                SuggestedCars = recommendation?.SuggestedCarIds ?? new List<string>(),
                PriceBand = $"{priceSuggestion?.SuggestedMinPrice ?? 0} ₺ - {priceSuggestion?.SuggestedMaxPrice ?? 0} ₺",
                Opportunity = priceSuggestion?.IsOpportunity ?? false,
                Segment = carSegment,
                City = city,
                UserId = userId
            };

            return View(vm);
        }
    }
}

