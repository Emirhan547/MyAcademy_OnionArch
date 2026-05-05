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
    public class RemoveServiceCommandHandler(IRepository<Service> _repository,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveServiceCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
           var service=await _repository.GetByIdAsync(request.Id);
            if(service is null)
            {
                return BaseResult<object>.Fail("Service Bulunamadı");
            }
            _repository.Delete(service);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Service silinemedi");
        }
    }
}
