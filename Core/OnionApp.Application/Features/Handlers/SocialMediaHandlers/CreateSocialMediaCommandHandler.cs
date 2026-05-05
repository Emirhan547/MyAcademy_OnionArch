using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.SocialMediaCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler(IRepository<SocialMedia> _repository,IValidator<CreateSocialMediaCommand> _validator,IUnitOfWork _unitOfWork) : IRequestHandler<CreateSocialMediaCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var validations = await _validator.ValidateAsync(request, cancellationToken);
            if (!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var mapped = request.Adapt<SocialMedia>();
            await _repository.CreateAsync(mapped);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Sosyal Medya Eklenemedi");
        }
    }
}
