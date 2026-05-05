using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.TagCloudServices;

namespace OnionApp.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCloudTagByBlogComponentPartial(ITagCloudService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogid = id;
            var result = await _service.GetTagCloudById(id);
            return View(result.Data);
        }
    }
}
