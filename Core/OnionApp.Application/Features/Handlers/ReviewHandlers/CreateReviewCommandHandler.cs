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
    public class CreateReviewCommandHandler (IRepository<Review> _repository,IUnitOfWork _unitOfWork): IRequestHandler<CreateReviewCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var mapped = request.Adapt<Review>();
            await _repository.CreateAsync(mapped);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Review Eklenemedi");
        }
    }
}
