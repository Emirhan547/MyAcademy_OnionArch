using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.LocationQueries;
using OnionApp.Application.Features.Results.LocationResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.LocationHandlers
{
    public class GetLocationsQueryHandler (IRepository<Location> _repository): IRequestHandler<GetLocationsQuery, BaseResult<List<GetLocationsQueryResult>>>
    {
        public async Task<BaseResult<List<GetLocationsQueryResult>>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await _repository.GetAllAsync();
            var mappedLocations=locations.Adapt<List<GetLocationsQueryResult>>();
            return BaseResult<List<GetLocationsQueryResult>>.Success(mappedLocations);
        }
    }
}
