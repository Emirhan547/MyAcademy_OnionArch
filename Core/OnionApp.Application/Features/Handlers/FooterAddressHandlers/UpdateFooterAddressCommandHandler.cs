using FluentValidation;
using Mapster;
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
    public class UpdateFooterAddressCommandHandler(IRepository<FooterAddress> _repository,IUnitOfWork _unitOfWork,IValidator<UpdateFooterAddressCommand> _validator) : IRequestHandler<UpdateFooterAddressCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var validations=await _validator.ValidateAsync(request, cancellationToken);
            if(!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var footerAddress = await _repository.GetByIdAsync(request.Id);
            if (footerAddress == null)
            {
                return BaseResult<object>.Fail("FooterAdress Bulunamadı");
            }
            var mapped = request.Adapt(footerAddress);
            _repository.Update(mapped);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("FooterAddress Güncellenemedi");
        }
    }
}
