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
    public class GetCarByIdQueryHandler(IRepository<Car> repository) : IRequestHandler<GetCarByIdQuery, BaseResult<GetCarByIdQueryResult>>
    {
        public async Task<BaseResult<GetCarByIdQueryResult>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await repository.GetByIdAsync(request.Id);
            if (car == null)
            {
                return BaseResult<GetCarByIdQueryResult>.Fail("Araba bulunamadı");
            }
            var mapped = car.Adapt<GetCarByIdQueryResult>();
            return BaseResult<GetCarByIdQueryResult>.Success(mapped);
        }
    }
}
