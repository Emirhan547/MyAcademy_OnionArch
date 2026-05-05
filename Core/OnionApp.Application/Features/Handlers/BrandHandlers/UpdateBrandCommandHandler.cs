using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BrandCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler (IRepository<Brand>_repository,IUnitOfWork _unitOfWork,IValidator<UpdateBrandCommand>_validator): IRequestHandler<UpdateBrandCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var validations = await _validator.ValidateAsync(request);
            if(!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
          var brands=await _repository.GetByIdAsync(request.Id);
            if (brands == null)
            {
                return BaseResult<object>.Fail("Güncellenecek Marka Bulunamadı");
            }
            brands.Adapt(request);

             _repository.Update(brands);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ?BaseResult<object>.Success("Marka Başarıyla Güncellendi"):BaseResult<object>.Fail("Marka Güncellenemedi");
        }
    }
}
