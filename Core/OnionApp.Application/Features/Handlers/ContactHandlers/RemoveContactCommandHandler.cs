using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BrandCommands;
using OnionApp.Application.Features.Commands.ContactCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler(IRepository<Contact> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveContactCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            var brands = await _repository.GetByIdAsync(request.Id);
            if (brands == null)
            {
                return BaseResult<object>.Fail("Silinecek Marka Bulunamadı");
            }
            _repository.Delete(brands);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success("Marka Başarıyla silindi") : BaseResult<object>.Fail("Marka Silinemedi");
        }
    }
}
