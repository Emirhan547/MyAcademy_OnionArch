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
    public class RemoveTestimonialCommandHandler (IRepository<Testimonial> _repository,IUnitOfWork _unitOfWork): IRequestHandler<RemoveTestimonialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial=await _repository.GetByIdAsync(request.Id);
            if (testimonial == null)
            {
                return BaseResult<object>.Fail("Testimonial Bulunamadı");
            }
            _repository.Delete(testimonial);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Testimonial Silinemedi");
        }
    }
}
