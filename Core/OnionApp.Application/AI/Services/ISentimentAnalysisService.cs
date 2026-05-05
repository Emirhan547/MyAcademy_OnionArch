using OnionApp.Application.AI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.AI.Services
{
    public interface ISentimentAnalysisService
    {
        Task<SentimentAnalysisResult> AnalyzeAsync(CancellationToken cancellationToken = default);
    }
}
