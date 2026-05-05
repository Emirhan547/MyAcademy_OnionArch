using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.CommentServices;

namespace OnionApp.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial(ICommentService _service):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var result = await _service.GetCommentsByBlogId(id);
            return View(result.Data);

        }
    }
}
