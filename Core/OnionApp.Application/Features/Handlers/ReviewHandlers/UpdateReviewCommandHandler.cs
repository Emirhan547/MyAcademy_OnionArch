using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ReviewCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.ReviewHandlers
{
    public class UpdateReviewCommandHandler(IRepository<Review> _repository,IUnitOfWork _unitOfWork) : IRequestHandler<UpdateReviewCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var result=await _repository.GetByIdAsync(request.Id);
            if(result == null)
            {
                return BaseResult<object>.Fail("Review Bulunamadı");
            }
            result = request.Adapt(result);
            _repository.Update(result);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Review Güncellenemedi");

        }
    }
}
