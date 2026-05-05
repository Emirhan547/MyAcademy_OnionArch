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
    public class GetCarCountByKmSmallerThen1000QueryHandler (IStatisticsRepository _repository): IRequestHandler<GetCarCountByKmSmallerThen1000Query, BaseResult<int>>
    {
        public async Task<BaseResult<int>> Handle(GetCarCountByKmSmallerThen1000Query request, CancellationToken cancellationToken)
        {
            var result =await _repository.GetCarCountByKmSmallerThen1000();
            return BaseResult<int>.Success(result);
        }
    }
}
