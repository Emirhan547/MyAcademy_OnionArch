using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.CarFeatureCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureByCarCommandHandler(ICarFeatureRepository _repository,IUnitOfWork _unitOfWork) : IRequestHandler<CreateCarFeatureByCarCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            var mapped = request.Adapt<CarFeature>();
             await _repository.CreateCarFeatureByCar(mapped);
            var uow=await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Eklendi");
        }
    }
}
