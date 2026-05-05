using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.CommentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.CommentQueries
{
    public class GetCommentCountQuery:IRequest<BaseResult<GetCommentCountQueryResult>>
    {
        public int Id { get; set; }

        public GetCommentCountQuery(int id)
        {
            Id = id;
        }
    }
}
