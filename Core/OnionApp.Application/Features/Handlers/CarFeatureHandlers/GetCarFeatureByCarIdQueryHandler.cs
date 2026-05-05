using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.CarFeatureQueries;
using OnionApp.Application.Features.Results.CarFeatureResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler (ICarFeatureRepository _repository): IRequestHandler<GetCarFeatureByCarIdQuery, BaseResult<List<GetCarFeatureByCarIdQueryResult>>>
    {
        public async Task<BaseResult<List<GetCarFeatureByCarIdQueryResult>>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetCarFeaturesByCarId(request.Id);
            if(results== null)
            {
                return BaseResult<List<GetCarFeatureByCarIdQueryResult>>.Fail("Bulunamadı");

            }
            var mapped = results.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                Id = x.Id,
                FeatureId = x.FeatureId,
                FeatureName = x.Feature?.Name ?? string.Empty,
                Available = x.Available
            }).ToList();

            return BaseResult<List<GetCarFeatureByCarIdQueryResult>>.Success(mapped);
        }
    }
}
