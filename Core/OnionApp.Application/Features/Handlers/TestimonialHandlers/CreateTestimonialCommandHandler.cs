using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.TestimonialCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler(IRepository<Testimonial> _repository,IValidator<CreateTestimonialCommand> _validator,IUnitOfWork _unitOfWork) : IRequestHandler<CreateTestimonialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var validation=await _validator.ValidateAsync(request);
            if(!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            var mapped = request.Adapt<Testimonial>();
            await _repository.CreateAsync(mapped);
            var uow=await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Testimonial Eklenemedi");
        }
    }
}
