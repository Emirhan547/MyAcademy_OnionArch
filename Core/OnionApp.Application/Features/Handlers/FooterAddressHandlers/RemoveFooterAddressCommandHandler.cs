using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.FooterAddressCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.FooterAddressHandlers
{
    public class RemoveFooterAddressCommandHandler(IRepository<FooterAddress> _repository,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveFooterAddressCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var footerAddress = await _repository.GetByIdAsync(request.Id);
            if (footerAddress == null)
            {
                return BaseResult<object>.Fail("Footer Address Bulunamadı");
            }
            _repository.Delete(footerAddress);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Footer Address Silinemedi");
        }
    }
}
