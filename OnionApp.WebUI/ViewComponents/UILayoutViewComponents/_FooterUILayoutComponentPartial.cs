using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.FooterAddressDtos;
using OnionApp.WebUI.Services.FooterAddressServices;

namespace UdemyCarBook.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial(IFooterAddressService _service) : ViewComponent
    {
       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _service.GetAllAsync();
            return View(values.Data);
        }
    }
}
