using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.BlogQueries;
using OnionApp.Application.Features.Results.BlogResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.BlogHandlers
{
    public class GetBlogByAuthorIdQueryHandler (IBlogRepository _repository): IRequestHandler<GetBlogByAuthorIdQuery, BaseResult<List<GetBlogByAuthorIdQueryResult>>>
    {
        public async Task<BaseResult<List<GetBlogByAuthorIdQueryResult>>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetBlogByAuthorId(request.Id);
            return BaseResult<List<GetBlogByAuthorIdQueryResult>>.Success(result.Adapt<List<GetBlogByAuthorIdQueryResult>>());
        }
    }
}
