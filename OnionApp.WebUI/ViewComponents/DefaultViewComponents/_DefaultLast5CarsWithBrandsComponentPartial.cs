using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.CarDtos;
using OnionApp.WebUI.Services.CarServices;

namespace OnionApp.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultLast5CarsWithBrandsComponentPartial(ICarService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _service.GetLast5CarWithBrands();

            return View(result?.Data ?? new List<ResultLast5CarsWithBrandsDto>());
        }
    }
}
