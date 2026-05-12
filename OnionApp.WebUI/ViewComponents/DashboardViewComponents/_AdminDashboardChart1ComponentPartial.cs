using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Models;
using OnionApp.WebUI.Services.StatisticsServices;

namespace OnionApp.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardChart1ComponentPartial(IStatisticsService statisticsService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new DashboardViewModel
            {
                AvgDailyPrice = (await statisticsService.GetAvgRentPriceForDaily()).Data,
                AvgWeeklyPrice = (await statisticsService.GetAvgRentPriceForWeekly()).Data,
                AvgMonthlyPrice = (await statisticsService.GetAvgRentPriceForMonthly()).Data
            };

            return View(model);
        }
    }
}
