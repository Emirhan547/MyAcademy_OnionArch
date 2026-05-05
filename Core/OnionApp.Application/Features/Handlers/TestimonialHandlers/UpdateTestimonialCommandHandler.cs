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
    public class UpdateTestimonialCommandHandler (IRepository<Testimonial> _repository,IValidator<UpdateTestimonialCommand> _validator,IUnitOfWork _unitOfWork): IRequestHandler<UpdateTestimonialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var validations = await _validator.ValidateAsync(request);
            if(!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var testimonial=await _repository.GetByIdAsync(request.Id);
            if(testimonial == null)
            {
                return BaseResult<object>.Fail("Testimonial Bulunamadı");
            }
            testimonial = request.Adapt(testimonial);
            _repository.Update(testimonial);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Testimonial Güncellenemedi");
        }
    }
}
