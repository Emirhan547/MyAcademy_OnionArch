using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.BlogServices;

namespace OnionApp.WebUI.ViewComponents.BlogViewComponents
{
    public class _GetLast3BlogsWithAuthorListComponentPartial(IBlogService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _service.GetAll3LastBlogsWithAuthorsAsync();
            return View(response.Data);
        }
    }
}
