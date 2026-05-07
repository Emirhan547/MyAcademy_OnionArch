using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.BrandCommands;
using OnionApp.Application.Features.Commands.CarCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler(IRepository<Car> repository, IUnitOfWork unitOfWork, ICarCountNotifier carCountNotifier) : IRequestHandler<RemoveCarCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            var car = await repository.GetByIdAsync(request.Id);
            if (car == null)
            {
                return BaseResult<object>.Fail("Silinecek araba bulunamadı");
            }
            repository.Delete(car);
            var isSuccess = await unitOfWork.SaveChangesAsync();
            if (isSuccess)
            {
                await carCountNotifier.NotifyCarCountAsync(cancellationToken);
                return BaseResult<object>.Success("Araba başarıyla silindi");
            }

            return BaseResult<object>.Fail("Araba silinemedi");
        }
    }
}
