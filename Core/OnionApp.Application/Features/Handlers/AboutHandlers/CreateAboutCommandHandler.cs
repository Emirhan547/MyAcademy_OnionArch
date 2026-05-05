using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.AboutCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler(IRepository<About>_repository,IUnitOfWork _unitOfWork,IValidator<CreateAboutCommand>_validator) : IRequestHandler<CreateAboutCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            var abouts=request.Adapt<About>();
            
            await _repository.CreateAsync(abouts);
            var result=await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(true) :BaseResult<object>.Fail("Ürün Eklenemedi");
        }
    }
}
