using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.ServiceServices;

namespace OnionApp.WebUI.ViewComponents.ServiceViewComponents
{
    public class _ServiceComponentPartial(IServiceService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await _service.GetAllAsync();
            return View(services.Data);
        }
    }
}
