using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ContactCommands;
using OnionApp.Domain.Entities;


namespace OnionApp.Application.Features.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler (IRepository<Contact> _repository,IUnitOfWork _unitOfWork,IValidator<CreateContactCommand> _validator): IRequestHandler<CreateContactCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            var mapped = request.Adapt<Contact>();
            
            await _repository.CreateAsync(mapped);
            var uow = await _unitOfWork.SaveChangesAsync();
            return uow ? BaseResult<object>.Success(true) : BaseResult<object>.Fail("Contact Eklenemedi");
            
        }
    }
}
