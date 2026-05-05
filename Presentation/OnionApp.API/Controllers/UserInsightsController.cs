using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.AI.Models;
using OnionApp.Application.AI.Services;

namespace OnionApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserInsightsController : ControllerBase
{
    private readonly IUserEventPublisher _userEventPublisher;
    private readonly IRecommendationService _recommendationService;
    private readonly IChurnPredictionService _churnPredictionService;
    private readonly ILogger<UserInsightsController> _logger;
    private readonly IPriceSuggestionService _priceSuggestionService;
    private readonly ISentimentAnalysisService _sentimentAnalysisService;
    public UserInsightsController(
        IUserEventPublisher userEventPublisher,
        IRecommendationService recommendationService,
        IChurnPredictionService churnPredictionService,
        IPriceSuggestionService priceSuggestionService,
        ISentimentAnalysisService sentimentAnalysisService,
        ILogger<UserInsightsController> logger)
    {
        _userEventPublisher = userEventPublisher;
        _recommendationService = recommendationService;
        _churnPredictionService = churnPredictionService;
        _priceSuggestionService = priceSuggestionService;
        _sentimentAnalysisService = sentimentAnalysisService;
        _logger = logger;
    }

    [HttpPost("events")]
    public async Task<IActionResult> PublishUserEvent([FromBody] UserEventMessage request, CancellationToken cancellationToken)
    {
        await _userEventPublisher.PublishAsync(request, cancellationToken);
        _logger.LogInformation("User-centric event tracked for {UserId}, feature {FeatureName}, event {EventType}", request.UserId, request.FeatureName, request.EventType);
        return Accepted();
    }

    [HttpGet("{userId}/recommendations")]
    public async Task<IActionResult> GetRecommendations(string userId, CancellationToken cancellationToken)
    {
        var result = await _recommendationService.GetRecommendationsAsync(userId, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{userId}/churn")]
    public async Task<IActionResult> GetChurnPrediction(string userId, CancellationToken cancellationToken)
    {
        var result = await _churnPredictionService.PredictAsync(userId, cancellationToken);
        return Ok(result);
    }
    [HttpGet("price-suggestion")]
    public async Task<IActionResult> GetPriceSuggestion([FromQuery] string city = "Istanbul", [FromQuery] string carSegment = "SUV", [FromQuery] DateOnly? pickupDate = null, [FromQuery] DateOnly? returnDate = null, CancellationToken cancellationToken = default)
    {
        var pickup = pickupDate ?? DateOnly.FromDateTime(DateTime.UtcNow.Date);
        var dropoff = returnDate ?? pickup.AddDays(3);
        var result = await _priceSuggestionService.SuggestAsync(city, carSegment, pickup, dropoff, cancellationToken);
        return Ok(result);
    }

    [HttpGet("sentiment")]
    public async Task<IActionResult> GetSentiment(CancellationToken cancellationToken)
    {
        var result = await _sentimentAnalysisService.AnalyzeAsync(cancellationToken);
        return Ok(result);
    }
}