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
    public class GetAvgRentPriceForWeeklyQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetAvgRentPriceForWeeklyQuery, BaseResult<decimal>>
    {
        public async Task<BaseResult<decimal>> Handle(GetAvgRentPriceForWeeklyQuery request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetAvgRentPriceForWeekly();
            return BaseResult<decimal>.Success(values);
        }
    }
}
