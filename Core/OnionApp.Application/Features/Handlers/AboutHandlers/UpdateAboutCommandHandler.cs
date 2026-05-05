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
    public class UpdateAboutCommandHandler(IRepository<About>_repository,IUnitOfWork _unitOfWork,IValidator<UpdateAboutCommand>_validator) : IRequestHandler<UpdateAboutCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            var product = await _repository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return BaseResult<object>.Fail("About bulunamadı");
            }


            _repository.Update(product);
            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(true) : BaseResult<object>.Fail("Ürün güncellenemedi");
        }
    }
}
