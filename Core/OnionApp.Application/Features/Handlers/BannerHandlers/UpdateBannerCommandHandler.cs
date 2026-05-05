using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BannerCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler(IRepository<Banner> _repository, IUnitOfWork _unitOfWork, IValidator<UpdateBannerCommand> _validator) : IRequestHandler<UpdateBannerCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var validations = await _validator.ValidateAsync(request);
            {
                if (!validations.IsValid)
                {
                    return BaseResult<object>.Fail(validations.Errors);
                }
                var values = await _repository.GetByIdAsync(request.Id);
                if (values == null)
                {
                    return BaseResult<object>.Fail("Banner Bulunamadı");
                }
                values.Adapt(request);
                _repository.Update(values);
                var uow = await _unitOfWork.SaveChangesAsync();
                return uow ? BaseResult<object>.Success() : BaseResult<object>.Fail("Banner Güncellenemedi");
            }
        }
    }
}
