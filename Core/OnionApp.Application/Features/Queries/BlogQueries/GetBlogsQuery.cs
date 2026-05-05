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
    public class GetBlogsQuery:IRequest<BaseResult<List<GetBlogsQueryResult>>>
    {
    }
}
