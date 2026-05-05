using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.LocationCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler(IRepository<Location> _repository,IValidator<CreateLocationCommand> _validator,IUnitOfWork _unitOfWork) : IRequestHandler<CreateLocationCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var validations=await _validator.ValidateAsync(request,cancellationToken);
            if(!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var mapped = request.Adapt<Location>();
            await _repository.CreateAsync(mapped);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Location Eklenemedi");
        }
    }
}
