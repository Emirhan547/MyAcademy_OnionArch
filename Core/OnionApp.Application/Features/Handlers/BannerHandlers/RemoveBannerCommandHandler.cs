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
    public class RemoveBannerCommandHandler (IRepository<Banner>_repository,IUnitOfWork _unitOfWork): IRequestHandler<RemoveBannerCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveBannerCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            if (values != null)
            {
                return BaseResult<object>.Fail("Banner Bulunamadı");
            }
            _repository.Delete(values);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ?BaseResult<object>.Success():BaseResult<object>.Fail("Banner Silinemdi");
        }
    }
}
