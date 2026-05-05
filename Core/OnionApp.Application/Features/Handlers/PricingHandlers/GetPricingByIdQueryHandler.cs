using FluentValidation;
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
    public class GetPricingByIdQueryHandler(IRepository<Pricing> _repository) : IRequestHandler<GetPricingByIdQuery, BaseResult<GetPricingByIdQueryResults>>
    {
        public async Task<BaseResult<GetPricingByIdQueryResults>> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var pricing=await _repository.GetByIdAsync(request.Id);
            if (pricing == null)
            {
                return BaseResult<GetPricingByIdQueryResults>.Fail("Priing Bulunamadı");
            }
            var mapped = pricing.Adapt<GetPricingByIdQueryResults>();
            return BaseResult<GetPricingByIdQueryResults>.Success(mapped);
        }
    }
}
