using Mapster;
using MapsterMapper;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.CarQueries;
using OnionApp.Application.Features.Results.CarResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler(ICarRepository repository) : IRequestHandler<GetCarWithBrandQuery, BaseResult<List<GetCarWithBrandQueryResult>>>
    {
        public async Task<BaseResult<List<GetCarWithBrandQueryResult>>> Handle(GetCarWithBrandQuery request, CancellationToken cancellationToken)
        {
            var cars = await repository.GetCarsListWithBrands();
            var response = cars.Adapt<List<GetCarWithBrandQueryResult>>();
            return BaseResult<List<GetCarWithBrandQueryResult>>.Success(response);
        }
    }
}
