using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.AboutResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.AboutQueries
{
    public class GetAboutsQuery:IRequest<BaseResult<List<GetAboutsQueryResult>>>
    {

    }
}
