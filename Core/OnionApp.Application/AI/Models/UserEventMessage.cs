namespace OnionApp.Application.AI.Models;

public sealed record UserEventMessage(
    string UserId,
    string SessionId,
    string EventType,
    string FeatureName,
    DateTime OccurredAtUtc,
    string CorrelationId,
    Dictionary<string, string>? Metadata = null);