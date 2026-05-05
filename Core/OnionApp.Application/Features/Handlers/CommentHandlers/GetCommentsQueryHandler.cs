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
    public class GetCommentsQueryHandler (IRepository<Comment> _repository): IRequestHandler<GetCommentsQuery, BaseResult<List<GetCommentsQueryResult>>>
    {
        public async Task<BaseResult<List<GetCommentsQueryResult>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _repository.GetAllAsync();
            return BaseResult<List<GetCommentsQueryResult>>.Success(comments.Adapt<List<GetCommentsQueryResult>>());
        }
    }
}
