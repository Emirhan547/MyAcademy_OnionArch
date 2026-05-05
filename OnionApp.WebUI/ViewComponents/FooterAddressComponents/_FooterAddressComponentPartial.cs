using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.FooterAddressDtos;
using OnionApp.WebUI.Services.FooterAddressServices;

namespace OnionApp.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentPartial(IFooterAddressService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _service.GetAllAsync();

            var data = result?.Data ?? new List<ResultFooterAddressDto>();

            return View(data);
        }
    }
}
