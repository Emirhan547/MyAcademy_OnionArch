using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.CarFeatureServices;

namespace OnionApp.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCarFeatureByCarIdComponentPartial(ICarFeatureService _service ):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.Carid = id;
            var result = await _service.GetCarFeaturesByCarId(id);
            return View(result.Data);
        }
    }
}
