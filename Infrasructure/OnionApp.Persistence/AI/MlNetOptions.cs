namespace OnionApp.Persistence.AI;

public sealed class MlNetOptions
{
    public const string SectionName = "MlNet";
    public string ChurnModelVersion { get; init; } = "churn-v1";
    public string RecommendationModelVersion { get; init; } = "recommendation-v1";
}