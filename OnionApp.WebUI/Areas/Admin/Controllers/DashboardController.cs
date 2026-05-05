using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Models;
using OnionApp.WebUI.Services.StatisticsServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class DashboardController(IStatisticsService statisticsService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                CarCount = (await statisticsService.GetCarCount()).Data,
                BrandCount = (await statisticsService.GetBrandCount()).Data,
                LocationCount = (await statisticsService.GetLocationCount()).Data,
                BlogCount = (await statisticsService.GetBlogCount()).Data,
                AuthorCount = (await statisticsService.GetAuthorCount()).Data,
                AutoTransmissionCount = (await statisticsService.GetCarCountByTranmissionIsAuto()).Data,
                ElectricCount = (await statisticsService.GetCarCountByFuelElectric()).Data,
                GasOrDieselCount = (await statisticsService.GetCarCountByFuelGasolineOrDiesel()).Data,
                UnderThousandKmCount = (await statisticsService.GetCarCountByKmSmallerThen1000()).Data,
                AvgDailyPrice = (await statisticsService.GetAvgRentPriceForDaily()).Data,
                AvgWeeklyPrice = (await statisticsService.GetAvgRentPriceForWeekly()).Data,
                AvgMonthlyPrice = (await statisticsService.GetAvgRentPriceForMonthly()).Data,
                TopBrand = (await statisticsService.GetBrandNameByMaxCar()).Data,
                MostCommentedBlog = (await statisticsService.GetBlogTitleByMaxBlogComment()).Data,
                MinDailyPriceCar = (await statisticsService.GetCarBrandAndModelByRentPriceDailyMin()).Data,
                MaxDailyPriceCar = (await statisticsService.GetCarBrandAndModelByRentPriceDailyMax()).Data
            };

            return View(model);
        }
    }
}
