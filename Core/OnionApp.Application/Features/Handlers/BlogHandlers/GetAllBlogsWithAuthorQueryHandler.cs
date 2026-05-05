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
    public class GetAllBlogsWithAuthorQueryHandler(IBlogRepository _repository) : IRequestHandler<GetAllBlogsWithAuthorQuery, BaseResult<List<GetAllBlogsWithAuthorQueryResult>>>
    {
        public async Task<BaseResult<List<GetAllBlogsWithAuthorQueryResult>>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var response = request.CategoryId.HasValue
                 ? await _repository.GetBlogsByCategoryId(request.CategoryId.Value)
                 : await _repository.GetAllBlogsWithAuthors();
            return BaseResult<List<GetAllBlogsWithAuthorQueryResult>>.Success(response.Adapt<List<GetAllBlogsWithAuthorQueryResult>>());
        }
    }
}
