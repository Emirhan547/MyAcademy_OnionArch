using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BrandCommands;
using OnionApp.Application.Features.Commands.CarCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.CarHandlers
{
    public class CreateCarCommandHandler(IRepository<Car> repository, IValidator<CreateCarCommand> validator, IUnitOfWork unitOfWork) : IRequestHandler<CreateCarCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var validations = await validator.ValidateAsync(request);
            if (!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var car = request.Adapt<Car>();
            await repository.CreateAsync(car);

            var isSuccess = await unitOfWork.SaveChangesAsync();
            return isSuccess ? BaseResult<object>.Success("Araba eklendi") : BaseResult<object>.Fail("Araba eklenemedi");
        }
    }
}