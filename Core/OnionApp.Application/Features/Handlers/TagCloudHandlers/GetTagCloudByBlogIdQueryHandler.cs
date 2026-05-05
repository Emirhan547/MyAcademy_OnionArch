using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.TagCloudQueries;
using OnionApp.Application.Features.Results.TagCloudResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler(ITagCloudRepository _repository) : IRequestHandler<GetTagCloudByBlogIdQuery, BaseResult<List<GetTagCloudByBlogIdQueryResult>>>
    {
        public async Task<BaseResult<List<GetTagCloudByBlogIdQueryResult>>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetTagCloudsByBlogId(request.Id);
            if (result == null)
            {
                return BaseResult<List<GetTagCloudByBlogIdQueryResult>>.Fail("Bulunamadı");
            }
            return BaseResult<List<GetTagCloudByBlogIdQueryResult>>.Success(result.Adapt<List<GetTagCloudByBlogIdQueryResult>>());
        }
    }
}
