using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.BlogQueries;
using OnionApp.Application.Features.Results.BlogResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler (IRepository<Blog> _repository): IRequestHandler<GetBlogByIdQuery, BaseResult<GetBlogByIdQueryResult>>
    {
        public async Task<BaseResult<GetBlogByIdQueryResult>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            if(blog == null)
            {
                return BaseResult<GetBlogByIdQueryResult>.Fail("Blog Bulunamadı");
            }
            return BaseResult<GetBlogByIdQueryResult>.Success(blog.Adapt<GetBlogByIdQueryResult>());
        }
    }
}
