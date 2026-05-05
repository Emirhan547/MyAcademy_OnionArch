using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.CarQueries;
using OnionApp.Application.Features.Results.CarResults;

namespace OnionApp.Application.Features.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQueryHandler(ICarRepository repository) : IRequestHandler<GetLast5CarsWithBrandQuery, BaseResult<List<GetLast5CarsWithBrandQueryResult>>>
    {
        public async Task<BaseResult<List<GetLast5CarsWithBrandQueryResult>>> Handle(GetLast5CarsWithBrandQuery request, CancellationToken cancellationToken)
        {
            var cars = await repository.GetLast5CarsWithBrands();
            var mapped = cars.Adapt<List<GetLast5CarsWithBrandQueryResult>>();
            return BaseResult<List<GetLast5CarsWithBrandQueryResult>>.Success(mapped);
        }
    }
}
