using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.PricingQueries;
using OnionApp.Application.Features.Results.PriceResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.PricingHandlers
{
    public class GetPricingsQueryHandler(IRepository<Pricing> _repository) : IRequestHandler<GetPricingsQuery, BaseResult<List<GetPricingsQueryResult>>>
    {
        public async Task<BaseResult<List<GetPricingsQueryResult>>> Handle(GetPricingsQuery request, CancellationToken cancellationToken)
        {
            var pricings = await _repository.GetAllAsync();
            var mapped = pricings.Adapt<List<GetPricingsQueryResult>>();
            return BaseResult<List<GetPricingsQueryResult>>.Success(mapped);
        }
    }
}
