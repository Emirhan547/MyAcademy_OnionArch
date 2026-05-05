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
    public class RemoveSocialMediaCommandHandler(IRepository<SocialMedia> _repository,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveSocialMediaCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socials = await _repository.GetByIdAsync(request.Id);
            if (socials is null)
            {
                return BaseResult<object>.Fail("Sosyal Medya Bulunamadı");
            }
            _repository.Delete(socials);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Sosyal Medya Silinemedi");
        }
    }
}
