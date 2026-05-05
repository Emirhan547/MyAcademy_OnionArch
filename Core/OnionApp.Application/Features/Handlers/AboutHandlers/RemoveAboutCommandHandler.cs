using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.AboutCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler(IRepository<About>_repository,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveAboutCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
        {
           var abouts=await _repository.GetByIdAsync(request.Id);
            _repository.Delete(abouts);
           var values=await _unitOfWork.SaveChangesAsync();
            return values ? BaseResult<object>.Success() : BaseResult<object>.Fail("Ürün silinemedi");
        }
    }
}
