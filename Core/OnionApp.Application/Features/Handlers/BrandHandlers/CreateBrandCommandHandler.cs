using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BannerCommands;
using OnionApp.Application.Features.Commands.BrandCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler(IRepository<Brand>_repository,IValidator<CreateBrandCommand>_validator,IUnitOfWork _unitOfWork ) : IRequestHandler<CreateBrandCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var validations = await _validator.ValidateAsync(request);
            if (!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var mapped= request.Adapt<Brand>();
            
            await _repository.CreateAsync(mapped);
            var uow=await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success("Kategori Eklendi"):BaseResult<object>.Fail("Kategori Eklenemedi");
        }
    }
}
