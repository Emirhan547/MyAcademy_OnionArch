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
    public class GetCarCountByFuelGasolineOrDieselQueryHandler (IStatisticsRepository _repository): IRequestHandler<GetCarCountByFuelGasolineOrDieselQuery, BaseResult<int>>
    {
        public async Task<BaseResult<int>> Handle(GetCarCountByFuelGasolineOrDieselQuery request, CancellationToken cancellationToken)
        {
            var result =await _repository.GetCarCountByFuelGasolineOrDiesel();
            return BaseResult<int>.Success(result);
        }
    }
}
