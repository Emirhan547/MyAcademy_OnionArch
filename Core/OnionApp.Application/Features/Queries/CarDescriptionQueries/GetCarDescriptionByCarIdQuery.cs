using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.CarDescriptionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByCarIdQuery:IRequest<BaseResult<GetCarDescriptionQueryResult>>
    {
        public int Id { get; set; }

        public GetCarDescriptionByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
