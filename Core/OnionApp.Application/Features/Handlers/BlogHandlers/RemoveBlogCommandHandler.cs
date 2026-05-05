using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BlogCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.BlogHandlers
{
    public class RemoveBlogCommandHandler (IRepository<Blog> _repository,IUnitOfWork _unitOfWork): IRequestHandler<RemoveBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var blog=await _repository.GetByIdAsync(request.Id);
            if(blog == null)
            {
                return BaseResult<object>.Fail("Bog Bulunamadı");
            }
             _repository.Delete(blog);
            var uow=await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Blog Silinemedi");
        }
    }
}
