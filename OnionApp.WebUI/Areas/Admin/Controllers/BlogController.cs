using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.BlogServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController (IBlogService _service): Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var blogs = await _service.GetAllBlogsWithAuthorAsync();
            return View(blogs.Data);
        }
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
