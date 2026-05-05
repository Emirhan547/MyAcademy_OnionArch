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
    public class CreateFooterAddressCommandHandler (IRepository<FooterAddress> _repository,IUnitOfWork _unitOfWork,IValidator<CreateFooterAddressCommand> _validator): IRequestHandler<CreateFooterAddressCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var validations=await _validator.ValidateAsync(request);
            if(!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var mapped = request.Adapt<FooterAddress>();
            await _repository.CreateAsync(mapped);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("FooterAddress Eklenemedi");
        }
    }
}
