using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.TagCloudDtos;
using OnionApp.WebUI.Services.TagCloudServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagCloudController(ITagCloudService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result=await _service.GetAllAsync();
            return View(result.Data);
        }
        public IActionResult CreateTagCloud()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudDto create)
        {
            await _service.CreateAsync(create);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateTagCloud(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return View(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudDto update)
        {
            await _service.UpdateAsync(update);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTagCloud(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
