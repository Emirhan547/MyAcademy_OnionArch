using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ServiceCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler (IRepository<Service>_repository,IUnitOfWork _unitOfWork,IValidator<UpdateServiceCommand> _validator): IRequestHandler<UpdateServiceCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var validations=await _validator.ValidateAsync(request);
            if (!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var services=await _repository.GetByIdAsync(request.Id);
            if(services is null)
            {
                return BaseResult<object>.Fail("Services Bulunamadı");
            }
           var mapped= request.Adapt(services);
            _repository.Update(mapped);
            var uow=await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Services Güncellenemedi");
        }
    }
}
