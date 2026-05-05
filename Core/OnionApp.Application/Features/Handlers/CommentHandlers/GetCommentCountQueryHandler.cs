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
    public class GetCommentCountQueryHandler(ICommentRepository _repository) : IRequestHandler<GetCommentCountQuery, BaseResult<GetCommentCountQueryResult>>
    {
        public Task<BaseResult<GetCommentCountQueryResult>> Handle(GetCommentCountQuery request, CancellationToken cancellationToken)
        {
            var comments = _repository.GetCountCommentByBlog(request.Id);

            return Task.FromResult(
                BaseResult<GetCommentCountQueryResult>.Success(
                    comments.Adapt<GetCommentCountQueryResult>()
                )
            );
        }
    }
}
