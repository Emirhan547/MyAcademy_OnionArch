using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.CarQueries;
using OnionApp.Application.Features.Results.CarResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.CarHandlers
{
    public class GetCarWithBrandByIdQueryHandler(ICarRepository repository) : IRequestHandler<GetCarWithBrandByIdQuery, BaseResult<GetCarWithBrandByIdQueryResult>>
    {
        public async Task<BaseResult<GetCarWithBrandByIdQueryResult>> Handle(GetCarWithBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await repository.GetCarWithBrandByIdAsync(request.Id);
            if (car == null)
            {
                return BaseResult<GetCarWithBrandByIdQueryResult>.Fail("Araba bulunamadı");
            }
            return BaseResult<GetCarWithBrandByIdQueryResult>.Success(new GetCarWithBrandByIdQueryResult
            {
                Id = car.Id,
                BrandId = car.BrandId,
                BrandName = car.Brand?.Name ?? string.Empty,
                Model = car.Model ?? string.Empty,
                CoverImageUrl = car.CoverImageUrl ?? string.Empty,
                Km = car.Km,
                Transmission = car.Transmission ?? string.Empty,
                Seat = car.Seat,
                Luggage = car.Luggage,
                Fuel = car.Fuel ?? string.Empty,
                BigImageUrl = car.BigImageUrl ?? string.Empty
            });
        }
    }
}
