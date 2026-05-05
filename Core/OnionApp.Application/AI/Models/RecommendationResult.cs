namespace OnionApp.Application.AI.Models;

public sealed record RecommendationResult(
    string UserId,
    IReadOnlyCollection<string> SuggestedCarIds,
    string ModelVersion,
    double ConfidenceScore);