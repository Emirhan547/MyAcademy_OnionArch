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
    public class GetTagCloudByIdQueryHandler (IRepository<TagCloud> _repository) : IRequestHandler<GetTagCloudByIdQuery, BaseResult<GetTagCloudByIdQueryResult>>
    {
        public async Task<BaseResult<GetTagCloudByIdQueryResult>> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var result=await _repository.GetByIdAsync(request.Id);
            if(result==null)
            {
                return BaseResult<GetTagCloudByIdQueryResult>.Fail("TagCloud Bulunamadı");
            }
            return BaseResult<GetTagCloudByIdQueryResult>.Success(result.Adapt<GetTagCloudByIdQueryResult>());
        }
    }
}
