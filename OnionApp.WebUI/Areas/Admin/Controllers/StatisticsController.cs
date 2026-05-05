using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Models;
using OnionApp.WebUI.Services.StatisticsServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new StatisticsViewModel
            {
                CarCount = (await _statisticsService.GetCarCount()).Data,
                LocationCount = (await _statisticsService.GetLocationCount()).Data,
                AuthorCount = (await _statisticsService.GetAuthorCount()).Data,
                BlogCount = (await _statisticsService.GetBlogCount()).Data,
                BrandCount = (await _statisticsService.GetBrandCount()).Data,

                AvgRentPriceForDaily = (await _statisticsService.GetAvgRentPriceForDaily()).Data,
                AvgRentPriceForWeekly = (await _statisticsService.GetAvgRentPriceForWeekly()).Data,
                AvgRentPriceForMonthly = (await _statisticsService.GetAvgRentPriceForMonthly()).Data,

                CarCountByTranmissionIsAuto = (await _statisticsService.GetCarCountByTranmissionIsAuto()).Data,
                CarCountByKmSmallerThen1000 = (await _statisticsService.GetCarCountByKmSmallerThen1000()).Data,
                CarCountByFuelGasolineOrDiesel = (await _statisticsService.GetCarCountByFuelGasolineOrDiesel()).Data,
                CarCountByFuelElectric = (await _statisticsService.GetCarCountByFuelElectric()).Data,

                CarBrandAndModelByRentPriceDailyMax = (await _statisticsService.GetCarBrandAndModelByRentPriceDailyMax()).Data,
                CarBrandAndModelByRentPriceDailyMin = (await _statisticsService.GetCarBrandAndModelByRentPriceDailyMin()).Data,
                BrandNameByMaxCar = (await _statisticsService.GetBrandNameByMaxCar()).Data,
                BlogTitleByMaxBlogComment = (await _statisticsService.GetBlogTitleByMaxBlogComment()).Data
            };

            return View(model);
        }
    }
}