using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.TestimonialServices;

namespace OnionApp.WebUI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponentPartial(ITestimonialService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials=await _service.GetAllAsync();
            return View(testimonials.Data);
        }
    }
}
