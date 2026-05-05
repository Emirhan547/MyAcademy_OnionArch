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
    public class GetFeatureByIdQueryHandler (IRepository<Feature> _repository) : IRequestHandler<GetFeatureByIdQuery, BaseResult<GetFeatureByIdQueryResult>>
    {
        public async Task<BaseResult<GetFeatureByIdQueryResult>> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var features=await _repository.GetByIdAsync(request.Id);
            if (features is null)
            {
                return BaseResult<GetFeatureByIdQueryResult>.Fail("Feature Bulunamadı");
            }
            var mapped = features.Adapt<GetFeatureByIdQueryResult>();
            return BaseResult<GetFeatureByIdQueryResult>.Success(mapped);
        }
    }
}
