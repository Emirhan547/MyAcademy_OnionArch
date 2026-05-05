using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.AuthorCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler(IRepository<Author> _repository,IUnitOfWork _unitOfWork,IValidator<UpdateAuthorCommand> _validator) : IRequestHandler<UpdateAuthorCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var validations = await _validator.ValidateAsync(request);
            if(!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var author = await _repository.GetByIdAsync(request.Id);
            author=request.Adapt(author);
            _repository.Update(author);
            var uow=await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Author Güncellenemedi");
        }
    }
}
