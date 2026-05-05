using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.TagCloudServices;

namespace OnionApp.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsTagCloudComponentPartial(ITagCloudService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogid = id;
            var values = await _service.GetTagCloudById(id);
            return View(values.Data);
        }
    }
}
