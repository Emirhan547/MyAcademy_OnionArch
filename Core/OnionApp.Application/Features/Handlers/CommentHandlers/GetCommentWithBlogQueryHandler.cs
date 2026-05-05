using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.CommentQueries;
using OnionApp.Application.Features.Results.CommentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.CommentHandlers
{
    public class GetCommentWithBlogQueryHandler (ICommentRepository _repository): IRequestHandler<GetCommentWithBlogQuery, BaseResult<List<GetCommentWithBlogQueryResult>>>
    {
        public async Task<BaseResult<List<GetCommentWithBlogQueryResult>>> Handle(GetCommentWithBlogQuery request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetCommentsByBlogId(request.Id);
            return BaseResult<List<GetCommentWithBlogQueryResult>>.Success(comment.Adapt<List<GetCommentWithBlogQueryResult>>());
        }
    }
}
