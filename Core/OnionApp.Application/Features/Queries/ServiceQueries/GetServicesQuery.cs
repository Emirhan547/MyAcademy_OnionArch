using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.ServiceQueries
{
    public record GetServicesQuery:IRequest<BaseResult<List<GetServicesQueryResult>>>
    {
    }
}
