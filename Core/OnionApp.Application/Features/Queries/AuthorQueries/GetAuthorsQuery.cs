using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.AuthorResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.AuthorQueries
{
    public class GetAuthorsQuery:IRequest<BaseResult<List<GetAuthorsQueryResult>>>
    {
        
    }
}
