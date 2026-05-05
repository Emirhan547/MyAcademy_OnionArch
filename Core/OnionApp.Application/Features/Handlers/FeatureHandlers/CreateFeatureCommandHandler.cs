using FluentValidation;
using Mapster;
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
    public class CreateFeatureCommandHandler(IRepository<Feature> _repository,IUnitOfWork _unitOfWork,IValidator<CreateFeatureCommand> _validator) : IRequestHandler<CreateFeatureCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var features=await _validator.ValidateAsync(request);
            if(!features.IsValid)
            {
                return BaseResult<object>.Fail(features.Errors);
            }
            var mapped = request.Adapt<Feature>();
            await _repository.CreateAsync(mapped);
           var uow= await _unitOfWork.SaveChangesAsync();
            return uow?BaseResult<object>.Success(uow):BaseResult<object>.Fail("Feature Eklenemedi");
        }
    }
}
