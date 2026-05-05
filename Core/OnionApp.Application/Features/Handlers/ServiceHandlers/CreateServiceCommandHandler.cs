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
    public class CreateServiceCommandHandler (IRepository<Service> _repository,IUnitOfWork _unitOfWork,IValidator<CreateServiceCommand> _validator): IRequestHandler<CreateServiceCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var validationService=await _validator.ValidateAsync(request);
            if (!validationService.IsValid)
            {
                return BaseResult<object>.Fail(validationService.Errors);
            }
            var mappedService = request.Adapt<Service>();
            await _repository.CreateAsync(mappedService);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(mappedService);
        }
    }
}
