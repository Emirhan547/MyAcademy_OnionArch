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
    public class UpdateSocialMediaCommandHandler(IRepository<SocialMedia> _repository,IUnitOfWork _unitOfWork,IValidator<UpdateSocialMediaCommand> _validator) : IRequestHandler<UpdateSocialMediaCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var validations = await _validator.ValidateAsync(request);
            if (!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var socials = await _repository.GetByIdAsync(request.Id);
            if (socials == null)
            {
                return BaseResult<object>.Fail("Sosyal Medya Bulunamadı");
            }
            var mapped = request.Adapt(socials);
            _repository.Update(mapped);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Sosyal Medya Güncellenemedi");
        }
    }
}
