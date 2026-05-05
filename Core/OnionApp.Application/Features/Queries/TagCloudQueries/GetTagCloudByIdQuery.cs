using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.TagCloudResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.TagCloudQueries
{
    public class GetTagCloudByIdQuery:IRequest<BaseResult<GetTagCloudByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetTagCloudByIdQuery(int id)
        {
            Id = id;
        }
    }
}
