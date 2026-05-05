using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.BlogServices;

namespace OnionApp.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardBlogListComponentPartial(IBlogService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _service.GetAllBlogsWithAuthorAsync();
            return View(blogs.Data);
        }
    }
}
