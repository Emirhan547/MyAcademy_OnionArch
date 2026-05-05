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
    public class GetLocationByIdQueryHandler(IRepository<Location> _repository) : IRequestHandler<GetLocationByIdQuery, BaseResult<GetLocationByIdQueryResult>>
    {
        public async Task<BaseResult<GetLocationByIdQueryResult>> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var locations=await _repository.GetByIdAsync(request.Id);
            if(locations == null)
            {
                return BaseResult<GetLocationByIdQueryResult>.Fail("Location bulunamadı");
            }
            var mapped=locations.Adapt<GetLocationByIdQueryResult>();
            return BaseResult<GetLocationByIdQueryResult>.Success(mapped);
        }
    }
}
