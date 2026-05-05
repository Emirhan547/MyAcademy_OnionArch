using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.PricingCommands;
using OnionApp.Domain.Entities;


namespace OnionApp.Application.Features.Handlers.PricingHandlers
{
    public class CreatePricingCommandHandler(IRepository<Pricing> _repository,IValidator<CreatePricingCommand> _validator,IUnitOfWork _unitOfWork) : IRequestHandler<CreatePricingCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            var validations=await _validator.ValidateAsync(request,cancellationToken);
            if(!validations.IsValid)
            {
                return BaseResult<object>.Fail(validations.Errors);
            }
            var mapped=request.Adapt<Pricing>();
            await _repository.CreateAsync(mapped);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(uow) : BaseResult<object>.Fail("Pricing Eklenemedi");
        }
    }
}
