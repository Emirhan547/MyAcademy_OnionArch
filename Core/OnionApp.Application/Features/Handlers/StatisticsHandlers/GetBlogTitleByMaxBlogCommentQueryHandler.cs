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
    public class GetBlogTitleByMaxBlogCommentQueryHandler (IStatisticsRepository _repository): IRequestHandler<GetBlogTitleByMaxBlogCommentQuery, BaseResult<string>>
    {
        public async Task<BaseResult<string>> Handle(GetBlogTitleByMaxBlogCommentQuery request, CancellationToken cancellationToken)
        {
            var result =await _repository.GetBlogTitleByMaxBlogComment();
            return BaseResult<string>.Success(result);
        }
    }
}
