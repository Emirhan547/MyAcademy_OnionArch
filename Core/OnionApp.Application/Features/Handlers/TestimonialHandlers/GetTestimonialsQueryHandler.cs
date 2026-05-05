using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.TestimonialQueries;
using OnionApp.Application.Features.Results.TestimonialResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.TestimonialHandlers
{
    public class GetTestimonialsQueryHandler(IRepository<Testimonial> _repository) : IRequestHandler<GetTestimonialsQuery, BaseResult<List<GetTestimonialsQueryResult>>>
    {
        public async Task<BaseResult<List<GetTestimonialsQueryResult>>> Handle(GetTestimonialsQuery request, CancellationToken cancellationToken)
        {
            var testimonials = await _repository.GetAllAsync();
            var mapped = testimonials.Adapt<List<GetTestimonialsQueryResult>>();
            return BaseResult<List<GetTestimonialsQueryResult>>.Success(mapped);
        }
    }
}
