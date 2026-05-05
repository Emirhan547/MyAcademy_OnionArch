using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.CategoryCommands;
using OnionApp.Domain.Entities;


namespace OnionApp.Application.Features.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler(IRepository<Category> _repository,
                                              IUnitOfWork _unitOfWork) : IRequestHandler<RemoveCategoryCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category is null)
            {
                return BaseResult<object>.Fail("Kategori bulunamadı");
            }

            _repository.Delete(category);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Kategori Silinemedi");
        }
    }
}
