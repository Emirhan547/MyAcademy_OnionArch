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
    public class RemovePricingCommandHandler (IRepository<Pricing> _repository,IUnitOfWork _unitOfWork): IRequestHandler<RemovePricingCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var pricing=await _repository.GetByIdAsync(request.Id);
            if (pricing == null)
            {
                return BaseResult<object>.Fail("Pricing Bulunamadı");
            }
            _repository.Delete(pricing);
            var uow=await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Pricing Silinemedi");
        }
    }
}
