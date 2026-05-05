using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.TestimonialResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery:IRequest<BaseResult<GetTestimonialByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetTestimonialByIdQuery(int id)
        {
            Id = id;
        }
    }
}
