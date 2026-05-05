using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.FeatureQueries;
using OnionApp.Application.Features.Results.FeatureResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.FeatureHandlers
{
    public class GetFeaturesQueryHandler(IRepository<Feature> _repository) : IRequestHandler<GetFeaturesQuery, BaseResult<List<GetFeaturesQueryResult>>>
    {
        public async Task<BaseResult<List<GetFeaturesQueryResult>>> Handle(GetFeaturesQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result = request.Adapt<List<GetFeaturesQueryResult>>();
            return BaseResult<List<GetFeaturesQueryResult>>.Success(result);
        }
    }
}
