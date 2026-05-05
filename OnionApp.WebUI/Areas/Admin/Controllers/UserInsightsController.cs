using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.UserInsightDtos;
using OnionApp.WebUI.Services.UserInsightServices;

namespace OnionApp.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/UserInsights")]
public class UserInsightsController(IUserInsightService userInsightService) : Controller
{
    [HttpGet("Index")]
    public async Task<IActionResult> Index(
        string userId = "demo-user-1",
        string city = "Istanbul",
        string carSegment = "SUV",
        DateOnly? pickupDate = null,
        DateOnly? returnDate = null,
        string? eventStatus = null)
    {
        var pickup = pickupDate ?? DateOnly.FromDateTime(DateTime.UtcNow);
        var dropoff = returnDate ?? pickup.AddDays(3);
        var vm = new UserInsightDashboardViewModel
        {
            UserId = userId,
            City = city,
            CarSegment = carSegment,
            PickupDate = pickup,
            ReturnDate = dropoff,
            EventStatus = eventStatus,
            Recommendation = await userInsightService.GetRecommendationsAsync(userId),
            ChurnPrediction = await userInsightService.GetChurnPredictionAsync(userId),
            PriceSuggestion = await userInsightService.GetPriceSuggestionAsync(city, carSegment, pickup, dropoff),
            Sentiment = await userInsightService.GetSentimentAsync()
,        };

        return View(vm);
    }

    [HttpPost("TrackDemoEvent")]
    public async Task<IActionResult> TrackDemoEvent(UserInsightDashboardViewModel vm)
    {
        var success = await userInsightService.PublishUserEventAsync(new UserEventMessageDto
        {
            UserId = vm.UserId,
            SessionId = HttpContext.TraceIdentifier,
            EventType = "dashboard.opened",
            FeatureName = "admin-user-insights",
            OccurredAtUtc = DateTime.UtcNow,
            CorrelationId = Guid.NewGuid().ToString("N"),
            Metadata = new Dictionary<string, string> { ["source"] = "webui-admin" }
        });

        return RedirectToAction("Index", new
        {
            userId = vm.UserId,
            city = vm.City,
            carSegment = vm.CarSegment,
            pickupDate = vm.PickupDate,
            returnDate = vm.ReturnDate,
            eventStatus = success ? "ok" : "fail"
        });
    }
}