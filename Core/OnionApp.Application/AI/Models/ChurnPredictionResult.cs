namespace OnionApp.Application.AI.Models;

public sealed record ChurnPredictionResult(
    string UserId,
    double RiskScore,
    string Segment,
    string ModelVersion,
    DateTime GeneratedAtUtc);