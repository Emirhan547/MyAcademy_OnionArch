using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.PricingCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler(IRepository<Pricing> _repository,IUnitOfWork _unitOfWork,IValidator<UpdatePricingCommand> _validator) : IRequestHandler<UpdatePricingCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var validations=await _validator.ValidateAsync(request);
            if(!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var pricings=await _repository.GetByIdAsync(request.Id);
            if(pricings == null)
            {
                return BaseResult<object>.Fail("Pricing Bulunamadı");
            }
            var mapped = request.Adapt(pricings);
            _repository.Update(mapped);
            var uow=await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Pricing Güncellenemedi");
        }
    }
}
