using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.PriceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.PricingQueries
{
    public class GetPricingsQuery:IRequest<BaseResult<List<GetPricingsQueryResult>>>
    {
    }
}
