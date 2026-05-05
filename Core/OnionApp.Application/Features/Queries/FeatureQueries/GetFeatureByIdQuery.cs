using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.FeatureResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery:IRequest<BaseResult<GetFeatureByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetFeatureByIdQuery(int id)
        {
            Id = id;
        }
    }
}
