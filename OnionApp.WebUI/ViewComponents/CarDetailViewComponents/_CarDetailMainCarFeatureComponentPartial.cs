using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.CarDtos;
using OnionApp.WebUI.Services.CarServices;

namespace OnionApp.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailMainCarFeatureComponentPartial(ICarService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var result = await _service.GetCarWithBrandByIdAsync(id);

            return View(result?.Data ?? new ResultCarWithBrandsDto());
        }
    }
}
