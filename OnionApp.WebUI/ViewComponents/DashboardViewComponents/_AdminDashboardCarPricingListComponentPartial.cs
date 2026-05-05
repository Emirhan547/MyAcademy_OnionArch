using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.CarPricingServices;

namespace OnionApp.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardCarPricingListComponentPartial(ICarPricingService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carPricings = await _service.GetCarPricingWithTimePeriod();
            return View(carPricings.Data);
        }
    }
}
