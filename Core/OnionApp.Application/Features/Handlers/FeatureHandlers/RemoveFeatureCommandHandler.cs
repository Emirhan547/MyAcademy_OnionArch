using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.FeatureCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler(IRepository<Feature> _repository,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveFeatureCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var features=await _repository.GetByIdAsync(request.Id);
            if(features == null)
            {
                return BaseResult<object>.Fail("Feature Bulunamadı");
            }
            _repository.Delete(features);
            var uow=await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Feature Silinemedi");
        }
    }
}
