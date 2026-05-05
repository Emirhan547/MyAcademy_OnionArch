using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.AI.Models
{
    public sealed record SentimentAnalysisResult(
    int PositiveCount,
    int NegativeCount,
    int NeutralCount,
    IReadOnlyCollection<string> ImprovementTopics,
    string ModelVersion,
    DateTime GeneratedAtUtc);
}
