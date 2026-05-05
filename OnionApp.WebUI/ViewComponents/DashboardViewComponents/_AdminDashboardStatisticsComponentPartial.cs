using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.StatisticsServices;
using OnionApp.WebUI.Dtos;
using OnionApp.WebUI.Dtos.DashboardStatsDtos;

namespace OnionApp.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardStatisticsComponentPartial(IStatisticsService _service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random random = new Random();

            var model = new DashboardStatsDto();

            var carCount = await _service.GetCarCount();
            if (carCount.IsSuccessful)
                model.CarCount = carCount.Data;

            var locationCount = await _service.GetLocationCount();
            if (locationCount.IsSuccessful)
                model.LocationCount = locationCount.Data;

            var brandCount = await _service.GetBrandCount();
            if (brandCount.IsSuccessful)
                model.BrandCount = brandCount.Data;

            var avgDaily = await _service.GetAvgRentPriceForDaily();
            if (avgDaily.IsSuccessful)
                model.AvgDaily = avgDaily.Data.ToString("0.00");

            // random değerleri ViewBag'de tutabiliriz (UI işi)
            ViewBag.CarRandom = random.Next(0, 101);
            ViewBag.LocationRandom = random.Next(0, 101);
            ViewBag.BrandRandom = random.Next(0, 101);
            ViewBag.AvgDailyRandom = random.Next(0, 101);

            return View(model); // 🔥 ARTIK MODEL GÖNDERİYORUZ
        }
    }
}