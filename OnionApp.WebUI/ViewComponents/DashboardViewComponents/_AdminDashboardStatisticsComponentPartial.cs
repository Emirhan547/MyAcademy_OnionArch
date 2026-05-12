using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos;
using OnionApp.WebUI.Dtos.DashboardStatsDtos;
using OnionApp.WebUI.Services.ReservationServices;
using OnionApp.WebUI.Services.StatisticsServices;

namespace OnionApp.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardStatisticsComponentPartial(IStatisticsService service, IReservationService reservationService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var random = new Random();

            var model = new DashboardStatsDto();

            var carCount = await service.GetCarCount();
            if (carCount.IsSuccessful)
                model.CarCount = carCount.Data;

            var locationCount = await service.GetLocationCount();
            if (locationCount.IsSuccessful)
                model.LocationCount = locationCount.Data;

            var brandCount = await service.GetBrandCount();
            if (brandCount.IsSuccessful)
                model.BrandCount = brandCount.Data;

            var avgDaily = await service.GetAvgRentPriceForDaily();
            if (avgDaily.IsSuccessful)
                model.AvgDaily = avgDaily.Data.ToString("0.00");
            var reservations = await reservationService.GetAllAsync();
            var utcToday = DateTime.UtcNow.Date;

            if (reservations.IsSuccessful && reservations.Data is not null)
            {
                var list = reservations.Data;
                model.TodayReservationCount = list.Count(x => x.PickUpDate.HasValue && x.PickUpDate.Value.Date == utcToday);
                model.PendingReservationCount = list.Count(x => string.Equals(x.Status, "Pending", StringComparison.OrdinalIgnoreCase));
                model.ActiveReservationCount = list.Count(x => string.Equals(x.Status, "Active", StringComparison.OrdinalIgnoreCase));
                model.TodayCheckOutCount = list.Count(x => x.CheckOutAt.HasValue && x.CheckOutAt.Value.Date == utcToday);
                model.TodayReturnCount = list.Count(x => x.ReturnDate.HasValue && x.ReturnDate.Value.Date == utcToday);
                model.ReservationLoadRate = model.CarCount == 0 ? 0 : Math.Round((decimal)model.ActiveReservationCount / model.CarCount * 100, 1);
            }

            model.GeneratedAt = DateTime.Now;

            ViewBag.CarRandom = random.Next(45, 96);
            ViewBag.LocationRandom = random.Next(40, 92);
            ViewBag.BrandRandom = random.Next(38, 90);
            ViewBag.AvgDailyRandom = random.Next(50, 98);

            return View(model);
        }
    }
}