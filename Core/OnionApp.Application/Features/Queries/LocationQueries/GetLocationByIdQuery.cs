using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.LocationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.LocationQueries
{
    public class GetLocationByIdQuery:IRequest<BaseResult<GetLocationByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetLocationByIdQuery(int İd)
        {
            Id = İd;
        }
    }
}
