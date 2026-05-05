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
    public class GetServiceByIdQuery:IRequest<BaseResult<GetServiceByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetServiceByIdQuery(int id)
        {
            Id = id;
        }
    }
}
