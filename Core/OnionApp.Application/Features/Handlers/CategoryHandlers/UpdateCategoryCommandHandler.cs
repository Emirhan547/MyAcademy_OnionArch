using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.CategoryCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler(IRepository<Category> _repository,
                                               IUnitOfWork _unitOfWork,
                                               IValidator<UpdateCategoryCommand> _validator) : IRequestHandler<UpdateCategoryCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            var category = await _repository.GetByIdAsync(request.Id);

            if (category is null)
            {
                return BaseResult<object>.Fail("Bu Id'ye ait Kategori bulunamadı");
            }
            category = request.Adapt(category);
            _repository.Update(category);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Güncelleme başarısız");



        }

    }
}