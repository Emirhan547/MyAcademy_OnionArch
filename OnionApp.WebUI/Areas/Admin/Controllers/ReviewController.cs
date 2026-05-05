using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.ReviewDtos;
using OnionApp.WebUI.Services.ReviewServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReviewController(IReviewService _service) : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.carId = id; 
            var reviews = await _service.GetReviewsByCarId(id);
            return View(reviews.Data);
        }
        public IActionResult CreateReview(int carId) => View(new CreateReviewDto { CarId = carId, ReviewDate = DateTime.Now });
        [HttpPost] public async Task<IActionResult> CreateReview(CreateReviewDto dto)
        {
            await _service.CreateAsync(dto);
            return RedirectToAction("Index", new { id = dto.CarId }); }
        public IActionResult UpdateReview(int carId, int id) => View(new UpdateReviewDto { Id = id, CarId = carId, ReviewDate = DateTime.Now });
        [HttpPost]
        public async Task<IActionResult> UpdateReview(UpdateReviewDto dto)
        {
            await _service.UpdateAsync(dto);
            return RedirectToAction("Index", new { id = dto.CarId }); }
        public async Task<IActionResult> DeleteReview(int id, int carId) 
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index", new { id = carId }); }
    }
}

