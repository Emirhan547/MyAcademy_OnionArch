using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.RentACarQueries;
using OnionApp.Application.Features.Results.RentACarResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.RentACarHandlers
{
    public class GetRentACarHandler(IRentACarRepository _repository) : IRequestHandler<GetRentACarQuery, BaseResult<List<GetRentACarQueryResult>>>
    {
        public async Task<BaseResult<List<GetRentACarQueryResult>>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == true);
            var results = values.Select(y => new GetRentACarQueryResult
            {
                CarId = y.CarId,
                Brand = y.Car.Brand.Name,
                Model = y.Car.Model,
                CoverImageUrl = y.Car.CoverImageUrl
            }).ToList();
            return BaseResult<List<GetRentACarQueryResult>>.Success(results);
        }

       
    }
}
