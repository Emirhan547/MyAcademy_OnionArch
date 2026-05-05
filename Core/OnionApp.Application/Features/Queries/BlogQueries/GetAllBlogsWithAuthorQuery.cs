using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.BlogResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.BlogQueries
{
    public class GetAllBlogsWithAuthorQuery:IRequest<BaseResult<List<GetAllBlogsWithAuthorQueryResult>>>
    {
        public int? CategoryId { get; set; }

        public GetAllBlogsWithAuthorQuery(int? categoryId = null)
        {
            CategoryId = categoryId;
        }
    }
}
