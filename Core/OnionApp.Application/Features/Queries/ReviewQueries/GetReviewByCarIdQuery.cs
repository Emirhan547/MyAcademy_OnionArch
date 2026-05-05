using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.ReviewResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.ReviewQueries
{
    public class GetReviewByCarIdQuery:IRequest<BaseResult<List<GetReviewByCarIdQueryResult>>>
    {
        public int Id { get; set; }

        public GetReviewByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
