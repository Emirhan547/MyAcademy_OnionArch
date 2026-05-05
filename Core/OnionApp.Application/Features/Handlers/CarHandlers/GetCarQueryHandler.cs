using FluentValidation;
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
    public class GetCarQueryHandler(IRepository<Car> repository) : IRequestHandler<GetCarQuery, BaseResult<List<GetCarsQueryResult>>>
    {
        public async Task<BaseResult<List<GetCarsQueryResult>>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var cars = await repository.GetAllAsync();
            var mapped = cars.Adapt<List<GetCarsQueryResult>>();
            return BaseResult<List<GetCarsQueryResult>>.Success(mapped);
        }
    }
}
