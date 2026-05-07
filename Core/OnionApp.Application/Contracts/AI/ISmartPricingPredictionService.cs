using OnionApp.Application.Features.Queries.AiQueries;
using OnionApp.Application.Features.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Contracts.AI
{
    public interface ISmartPricingPredictionService
    {
        Task<SmartPricingResult> PredictDailyPriceAsync(GetSmartPricingAiQuery request, CancellationToken cancellationToken = default);
    }
}
