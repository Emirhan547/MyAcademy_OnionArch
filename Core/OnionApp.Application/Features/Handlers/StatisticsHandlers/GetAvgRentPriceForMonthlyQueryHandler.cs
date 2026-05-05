using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.StatisticsQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.StatisticsHandlers
{
    public class GetAvgRentPriceForMonthlyQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetAvgRentPriceForMonthlyQuery, BaseResult<decimal>>
    {
        public async Task<BaseResult<decimal>> Handle(GetAvgRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
        {
            var result =await _repository.GetAvgRentPriceForMonthly();
            return BaseResult<decimal>.Success(result);
        }
    }
}
