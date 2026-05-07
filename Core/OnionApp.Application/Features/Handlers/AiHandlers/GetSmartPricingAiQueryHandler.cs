using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts.AI;
using OnionApp.Application.Features.Queries.AiQueries;
using OnionApp.Application.Features.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.AiHandlers
{
    public sealed class GetSmartPricingAiQueryHandler(ISmartPricingPredictionService pricingService)
       : IRequestHandler<GetSmartPricingAiQuery, BaseResult<SmartPricingResult>>
    {
        public async Task<BaseResult<SmartPricingResult>> Handle(GetSmartPricingAiQuery request, CancellationToken cancellationToken)
        {
            var result = await pricingService.PredictDailyPriceAsync(request, cancellationToken);
            return BaseResult<SmartPricingResult>.Success(result);
        }
    }
}
