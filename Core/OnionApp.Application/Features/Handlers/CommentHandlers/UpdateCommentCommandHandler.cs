using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.CommentCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.CommentHandlers
{
    public class UpdateCommentCommandHandler (IRepository<Comment> _repository,IUnitOfWork _unitOfWork,IValidator<UpdateCommentCommand> _validator): IRequestHandler<UpdateCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var validations = await _validator.ValidateAsync(request);
            if(!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var comment=await _repository.GetByIdAsync(request.Id);
            if(comment == null)
            {
                return BaseResult<object>.Fail("Comment Bulunamadı");
            }
            comment=request.Adapt(comment);
            _repository.Update(comment);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Comment Güncellenemdi");
        }
    }
}
