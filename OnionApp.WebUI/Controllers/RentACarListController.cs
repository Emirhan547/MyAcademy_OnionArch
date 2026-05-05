using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionApp.WebUI.Dtos.RentACarDtos;
using OnionApp.WebUI.Models;
using OnionApp.WebUI.Services.RentACarServices;
using System.Net.Http;
using System.Text;


namespace UdemyCarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IRentACarService _rentACarService;
        public RentACarListController(IRentACarService rentACarService)
        {
            _rentACarService = rentACarService;
           
        }

        public async Task<IActionResult> Index(int id, string userId = "demo-user-1", string city = "Istanbul", string carSegment = "SUV")
        {
            var locationID = TempData["locationID"];

            if (locationID == null)
                return View(new RentACarListVM());

            id = int.Parse(locationID.ToString()!);

            var values = await _rentACarService.GetAvailableCarsAsync(id);

           

            var vm = new RentACarListVM
            {
                Cars = values ?? new List<FilterRentACarDto>(),
              
                SuggestedCars = new List<string>(),
                PriceBand = string.Empty,
                Opportunity = false,
                Segment = carSegment,
                City = city,
                UserId = userId
            };

            return View(vm);
        }
    }
}