using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.CommentQueries;
using OnionApp.Application.Features.Results.CommentResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.CommentHandlers
{
    public class GetCommentByIdQueryHandler(IRepository<Comment> _repository) : IRequestHandler<GetCommentByIdQuery, BaseResult<GetCommentByIdQueryResult>>
    {
        public async Task<BaseResult<GetCommentByIdQueryResult>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.Id);
            if(comment == null)
            {
                return BaseResult<GetCommentByIdQueryResult>.Fail("Comment Bulunamadı");
            }
            return BaseResult<GetCommentByIdQueryResult>.Success(comment.Adapt<GetCommentByIdQueryResult>());
        }
    }
}
