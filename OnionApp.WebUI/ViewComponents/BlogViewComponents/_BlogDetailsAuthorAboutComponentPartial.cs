using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.BlogServices;

namespace OnionApp.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsAuthorAboutComponentPartial(IBlogService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var result = await _service.GetBlogByAuthorId(id);
            return View(result.Data);
        }
    }
}
