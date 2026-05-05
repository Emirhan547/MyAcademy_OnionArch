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
    public class GetCarCountByTranmissionIsAutoQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetCarCountByTranmissionIsAutoQuery, BaseResult<int>>
    {
        public async Task<BaseResult<int>> Handle(GetCarCountByTranmissionIsAutoQuery request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetCarCountByTranmissionIsAuto();
            return BaseResult<int>.Success(value);
        }
    }
}
