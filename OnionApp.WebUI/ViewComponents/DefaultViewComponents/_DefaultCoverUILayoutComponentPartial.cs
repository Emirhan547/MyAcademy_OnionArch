using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.BannerServices;

namespace OnionApp.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCoverUILayoutComponentPartial(IBannerService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banners=await _service.GetAllAsync();
            return View(banners.Data);
        }
    }
}
