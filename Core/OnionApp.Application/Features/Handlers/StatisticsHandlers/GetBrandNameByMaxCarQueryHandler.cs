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
    public class GetBrandNameByMaxCarQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetBrandNameByMaxCarQuery, BaseResult<string>>
    {
        public async Task<BaseResult<string>> Handle(GetBrandNameByMaxCarQuery request, CancellationToken cancellationToken)
        {
            var result =await _repository.GetBrandNameByMaxCar();
            return BaseResult<string>.Success(result);
        }
    }
}
