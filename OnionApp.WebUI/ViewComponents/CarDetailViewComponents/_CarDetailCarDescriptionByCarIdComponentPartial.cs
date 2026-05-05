using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.CarDescriptionDtos;
using OnionApp.WebUI.Dtos.CarDtos;
using OnionApp.WebUI.Services.CarDescriptionServices;

namespace OnionApp.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCarDescriptionByCarIdComponentPartial(ICarDescriptionService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carid = id;
            var result = await _service.GetCarDescription(id);
            return View(result?.Data ?? new ResultCarDescriptionByCarIdDto());
        }
    }
} 
