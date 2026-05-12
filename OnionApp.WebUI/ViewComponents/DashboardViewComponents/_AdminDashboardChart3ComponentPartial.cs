using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Models;
using OnionApp.WebUI.Services.StatisticsServices;

namespace OnionApp.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardChart3ComponentPartial(IStatisticsService statisticsService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new DashboardViewModel
            {
                CarCount = (await statisticsService.GetCarCount()).Data,
                UnderThousandKmCount = (await statisticsService.GetCarCountByKmSmallerThen1000()).Data,
                AutoTransmissionCount = (await statisticsService.GetCarCountByTranmissionIsAuto()).Data,
                BlogCount = (await statisticsService.GetBlogCount()).Data
            };

            return View(model);
        }
    }
}
