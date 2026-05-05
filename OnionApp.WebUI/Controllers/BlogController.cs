using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.CommentDtos;
using OnionApp.WebUI.Models;
using OnionApp.WebUI.Services.BlogServices;
using OnionApp.WebUI.Services.CommentServices;

namespace OnionApp.WebUI.Controllers
{
    public class BlogController(IBlogService _service,ICommentService _commentService) : Controller
    {
        public async Task<IActionResult> Index(int? categoryId = null)
        {
            var result = await _service.GetAllBlogsWithAuthorAsync(categoryId);
            return View(result.Data);
        }
        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.blogid = id;

            var blogResult = await _service.GetByIdAsync(id);
            var commentResult = await _commentService.GetCountCommentByBlogAsync(id);

            var model = new BlogDetailViewModel
            {
                BlogId = id,
                Blog = blogResult.Data, // 🔥 KRİTİK
                CommentCount = commentResult.Data ?? new ResultCommentCountDto()
            };

            return View(model);
        }
        public PartialViewResult AddComment(int id)
        {
            return PartialView(id);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto create)
        {
            await _commentService.CreateAsync(create);
            return RedirectToAction("Index","Default");
        }
    }
}
