using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.AboutServices;

namespace OnionApp.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial(IAboutService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var abouts=await _service.GetAllAsync();
            return View(abouts.Data);
        }
    }
}
