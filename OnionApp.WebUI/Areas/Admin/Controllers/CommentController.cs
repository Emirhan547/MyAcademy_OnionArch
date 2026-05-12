using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.CommentServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController (ICommentService _service): Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            var response = await _service.GetCommentsByBlogId(id);

            ViewBag.v = id;

            return View(response.Data);
        }
    }
}
