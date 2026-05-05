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
    public class GetBlogCountQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetBlogCountQuery, BaseResult<int>>
    {
        public async Task<BaseResult<int>> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
        {
            var result =await _repository.GetBlogCount();
            return BaseResult<int>.Success(result);
        }
    }
}
