using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.ReviewQueries;
using OnionApp.Application.Features.Results.ReviewResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler(IReviewRepository _repository) : IRequestHandler<GetReviewByCarIdQuery, BaseResult<List<GetReviewByCarIdQueryResult>>>
    {
        public async Task<BaseResult<List<GetReviewByCarIdQueryResult>>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetReviewsByCarId(request.Id);
            if(result == null)
            {
                return BaseResult<List<GetReviewByCarIdQueryResult>>.Fail("Review Bulunamadı");
            }
            return BaseResult<List<GetReviewByCarIdQueryResult>>.Success(result.Adapt<List<GetReviewByCarIdQueryResult>>());
        }
    }
}
