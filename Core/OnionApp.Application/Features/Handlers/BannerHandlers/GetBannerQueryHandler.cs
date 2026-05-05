using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.BannerQueries;
using OnionApp.Application.Features.Results.BannerResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler(IRepository<Banner>_repository) : IRequestHandler<GetBannersQuery, BaseResult<List<GetBannersQueryResult>>>
    {
        public async Task<BaseResult<List<GetBannersQueryResult>>> Handle(GetBannersQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
             var mappedValues=values.Adapt<List<GetBannersQueryResult>>();
            return BaseResult<List<GetBannersQueryResult>>.Success(mappedValues);
        }
    }
}
