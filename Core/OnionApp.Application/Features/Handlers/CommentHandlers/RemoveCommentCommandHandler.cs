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
    public class RemoveCommentCommandHandler (IRepository<Comment> _repository,IUnitOfWork _unitOfWork): IRequestHandler<RemoveCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var comment=await _repository.GetByIdAsync(request.Id);
            if (comment == null)
            {
                return BaseResult<object>.Fail("Comment Bulunamadı");
            }
            _repository.Delete(comment);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Comment Silinemedi");
        }
    }
}
