using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.ReservationDtos;
using OnionApp.WebUI.Services.ReservationServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ReservationController(IReservationService _service) : Controller
    {
        public async Task<IActionResult> Index() 
        {
            var values = await _service.GetAllAsync();
            return View(values.Data ?? new List<ResultReservationDto>());
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(UpdateReservationCheckOutDto dto)
        {
            await _service.CheckOutAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UnreadCount()
        {
            var count = await _service.GetUnreadCountAsync();
            return Json(new { count });
        }

        [HttpGet]
        public async Task<IActionResult> RecentNotifications()
        {
            var items = await _service.GetRecentNotificationsAsync();
            return Json(items);
        }
        [HttpPost]
        public async Task<IActionResult> CheckIn(UpdateReservationCheckInDto dto)
        {
            await _service.CheckInAsync(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
