using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.RentACarResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.RentACarQueries
{
    public class GetRentACarQuery:IRequest<BaseResult<List<GetRentACarQueryResult>>>
    {
        public int LocationId { get; set; }
        public bool Available { get; set; }

    }
}
