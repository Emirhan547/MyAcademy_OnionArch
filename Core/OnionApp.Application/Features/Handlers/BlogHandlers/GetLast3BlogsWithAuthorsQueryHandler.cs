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
    public class GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository _repository) : IRequestHandler<GetLast3BlogsWithAuthorsQuery, BaseResult<List<GetLast3BlogsWithAuthorsQueryResult>>>
    {
        public async Task<BaseResult<List<GetLast3BlogsWithAuthorsQueryResult>>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _repository.GetLast3BlogsWithAuthorsAsync();
            return BaseResult<List<GetLast3BlogsWithAuthorsQueryResult>>.Success(blogs.Adapt<List<GetLast3BlogsWithAuthorsQueryResult>>());
        }
    }
}
