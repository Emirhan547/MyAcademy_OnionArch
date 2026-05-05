using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.TagCloudQueries;
using OnionApp.Application.Features.Results.TagCloudResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.TagCloudHandlers
{
    public class GetTagCloudsQueryHandler(IRepository<TagCloud> _repository) : IRequestHandler<GetTagCloudsQuery, BaseResult<List<GetTagCloudsQueryResult>>>
    {
        public async Task<BaseResult<List<GetTagCloudsQueryResult>>> Handle(GetTagCloudsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();
            return BaseResult<List<GetTagCloudsQueryResult>>.Success(result.Adapt<List<GetTagCloudsQueryResult>>());
        }
    }
}
