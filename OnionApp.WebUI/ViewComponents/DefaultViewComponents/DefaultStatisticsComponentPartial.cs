using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.StatisticsServices;

namespace OnionApp.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IStatisticsService _statisticsService;

        public _DefaultStatisticsComponentPartial(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carCount = await _statisticsService.GetCarCount();
            var locationCount = await _statisticsService.GetLocationCount();
            var brandCount = await _statisticsService.GetBrandCount();
            var electricCarCount = await _statisticsService.GetCarCountByFuelElectric();

            ViewBag.carCount = carCount.Data;
            ViewBag.locationCount = locationCount.Data;
            ViewBag.brandCount = brandCount.Data;
            ViewBag.carCountByFuelElectric = electricCarCount.Data;

            return View();
        }
    }
}