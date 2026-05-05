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
    public class UpdateFeatureCommandHandler(IRepository<Feature> _repository,IValidator<UpdateFeatureCommand> _validator,IUnitOfWork _unitOfWork) : IRequestHandler<UpdateFeatureCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var validations=await _validator.ValidateAsync(request, cancellationToken);
            if (!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var features = await _repository.GetByIdAsync(request.Id);
            if(features == null)
            {
                return BaseResult<object>.Fail("Feature Bulunamadı");
            }
           var mapped= request.Adapt(features);
            _repository.Update(mapped);
            var uow=await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Feature Güncellenemedi");

        }
    }
}
