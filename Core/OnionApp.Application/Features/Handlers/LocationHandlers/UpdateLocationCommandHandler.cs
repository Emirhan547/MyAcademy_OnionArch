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
    public class UpdateLocationCommandHandler(IRepository<Location> _repository,IValidator<UpdateLocationCommand> _validator,IUnitOfWork _unitOfWork) : IRequestHandler<UpdateLocationCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var validations=await _validator.ValidateAsync(request);
            if(!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var locations = await _repository.GetByIdAsync(request.Id);
            if(locations == null)
            {
                return BaseResult<object>.Fail("Location Bulunamadı");
            }
            var mapped = request.Adapt(locations);
            _repository.Update(mapped);
            var uow=await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Location Güncellenemedi");
        }
    }
}
