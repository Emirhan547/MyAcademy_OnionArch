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
    public class CreateCommentCommandHandler(IRepository<Comment> _repository,IUnitOfWork _unitOfWork,IValidator<CreateCommentCommand> _validator) : IRequestHandler<CreateCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var validations = await _validator.ValidateAsync(request);
            if(!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var mapped = request.Adapt<Comment>();
            await _repository.CreateAsync(mapped);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Comment Eklenemedi");
        }
    }
}
