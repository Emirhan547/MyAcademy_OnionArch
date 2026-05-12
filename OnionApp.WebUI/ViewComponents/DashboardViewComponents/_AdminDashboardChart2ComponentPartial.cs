using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Models;
using OnionApp.WebUI.Services.StatisticsServices;

namespace OnionApp.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardChart2ComponentPartial(IStatisticsService statisticsService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new DashboardViewModel
            {
                ElectricCount = (await statisticsService.GetCarCountByFuelElectric()).Data,
                GasOrDieselCount = (await statisticsService.GetCarCountByFuelGasolineOrDiesel()).Data
            };

            return View(model);
        }
    }
}
