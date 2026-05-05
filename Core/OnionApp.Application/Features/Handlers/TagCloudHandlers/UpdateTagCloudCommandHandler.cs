using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.TagCloudCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudCommandHandler (IRepository<TagCloud> _repository,IUnitOfWork _unitOfWork,IValidator<UpdateTagCloudCommand> _validator): IRequestHandler<UpdateTagCloudCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var validations=await _validator.ValidateAsync(request);
            if(!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var tagCloud=await _repository.GetByIdAsync(request.Id);
            if(tagCloud == null)
            {
                return BaseResult<object>.Fail("BlogTagBulunmadı");
            }
            tagCloud=request.Adapt(tagCloud);
            _repository.Update(tagCloud);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("BlogTag Güncelenemedi");
        }
    }
}
