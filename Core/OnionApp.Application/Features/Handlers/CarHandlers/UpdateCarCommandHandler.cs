using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.CarCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler(IRepository<Car> repository, IUnitOfWork unitOfWork, IValidator<UpdateCarCommand> validator) : IRequestHandler<UpdateCarCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var validations = await validator.ValidateAsync(request);
            if (!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var car = await repository.GetByIdAsync(request.Id);
            if (car == null)
            {
                return BaseResult<object>.Fail("Banner Bulunamadı");
            }
            request.Adapt(car);
            repository.Update(car);
            var isSuccess = await unitOfWork.SaveChangesAsync();
            return isSuccess ? BaseResult<object>.Success() : BaseResult<object>.Fail("Araba güncellenemedi");
        }
    }
}
