using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.StatisticsQueries;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.StatisticsHandlers
{
    public class GetCarCountQueryHandler(ICarRepository _repository) : IRequestHandler<GetCarCountQuery, BaseResult<int>>
    {
        public async Task<BaseResult<int>> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var cars =await _repository.GetCarCount();
            return BaseResult<int>.Success(cars);
        }
    }
}
