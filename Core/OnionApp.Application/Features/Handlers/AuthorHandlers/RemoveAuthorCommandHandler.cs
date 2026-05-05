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
    public class RemoveAuthorCommandHandler(IRepository<Author> _repository,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveAuthorCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);
            if (author == null)
            {
                return BaseResult<object>.Fail("Author Bulunamadı");
            }
            _repository.Delete(author);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow): BaseResult<object>.Fail("Author Silinemedi");
        }
    }
}
