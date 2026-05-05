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
    public class CreateTagCloudCommandHandler(IRepository<TagCloud> _repository,IUnitOfWork _unitOfWork,IValidator<CreateTagCloudCommand> _validator) : IRequestHandler<CreateTagCloudCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
           var validations=await _validator.ValidateAsync(request);
            if(!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var mapped = request.Adapt<TagCloud>();
            await _repository.CreateAsync(mapped);
            var uow=await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("TagCloud Eklenemedi");
        }
    }
}
