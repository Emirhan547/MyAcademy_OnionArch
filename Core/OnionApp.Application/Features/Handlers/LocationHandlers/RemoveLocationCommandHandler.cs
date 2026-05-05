using FluentValidation;
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
    public class RemoveLocationCommandHandler(IRepository<Location> _repository,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveLocationCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            var locations = await _repository.GetByIdAsync(request.Id);
            if(locations is null)
            {
                return BaseResult<object>.Fail("Location Bulunamadı");
            }
            _repository.Delete(locations);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Location Silinemedi");
        }
    }
}
