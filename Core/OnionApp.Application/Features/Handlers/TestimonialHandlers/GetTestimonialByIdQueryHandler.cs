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
    public class GetTestimonialByIdQueryHandler(IRepository<Testimonial> _repository) : IRequestHandler<GetTestimonialByIdQuery, BaseResult<GetTestimonialByIdQueryResult>>
    {
        public async Task<BaseResult<GetTestimonialByIdQueryResult>> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var testimonial=await _repository.GetByIdAsync(request.Id);
            if (testimonial == null)
            {
                return BaseResult<GetTestimonialByIdQueryResult>.Fail("Testimonial Bulunamadı");
            }
            return BaseResult<GetTestimonialByIdQueryResult>.Success(testimonial.Adapt<GetTestimonialByIdQueryResult>());
        }
    }
}
