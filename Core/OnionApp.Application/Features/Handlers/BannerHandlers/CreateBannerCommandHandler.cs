using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BannerCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler (IRepository<Banner>_repository,IUnitOfWork _unitOfWork,IValidator<CreateBannerCommand>_validator): IRequestHandler<CreateBannerCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            var values = request.Adapt<Banner>();
            
            await _repository.CreateAsync(values);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(true) : BaseResult<object>.Fail("Banner Eklenemedi");
        }
    }
}
