using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.CarPricingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.CarPricingQueries
{
    public class GetCarPricingWithTimePeriodQuery:IRequest<BaseResult<List<GetCarPricingWithTimePeriodQueryResut>>>
    {
    }
}
