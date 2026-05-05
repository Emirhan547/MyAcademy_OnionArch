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
    public class RemoveTagCloudCommandHandler(IRepository<TagCloud> _repository,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveTagCloudCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveTagCloudCommand request, CancellationToken cancellationToken)
        {
            var result=await _repository.GetByIdAsync(request.Id);
            if(result==null)
            {
                return BaseResult<object>.Fail("TagCloud Bulunamadı");
            }
            _repository.Delete(result);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("TagCloud Silinemedi");

        }
    }
}
