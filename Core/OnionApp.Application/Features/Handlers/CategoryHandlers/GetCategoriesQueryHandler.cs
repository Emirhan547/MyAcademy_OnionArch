using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.CategoryQueries;
using OnionApp.Application.Features.Results.CategoryResults;
using OnionApp.Domain.Entities;


namespace OnionApp.Application.Features.Handlers.CategoryHandlers
{
    public class GetCategoriesQueryHandler(IRepository<Category> _repository) : IRequestHandler<GetCategoriesQuery, BaseResult<List<GetCategoriesQueryResult>>>
    {
        public async Task<BaseResult<List<GetCategoriesQueryResult>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();
            var mappedCategories = categories.Adapt<List<GetCategoriesQueryResult>>();
            return BaseResult<List<GetCategoriesQueryResult>>.Success(mappedCategories);
        }
    }
}
