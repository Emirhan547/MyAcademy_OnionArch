using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.CarFeatureResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.CarFeatureQueries
{
    public class GetCarFeatureByCarIdQuery:IRequest<BaseResult<List<GetCarFeatureByCarIdQueryResult>>>
    {
        public int Id { get; set; }

        public GetCarFeatureByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
