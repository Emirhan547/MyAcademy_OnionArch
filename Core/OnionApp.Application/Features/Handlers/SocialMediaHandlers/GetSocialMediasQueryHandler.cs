using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.SocialMediaQueries;
using OnionApp.Application.Features.Results.LocationResults;
using OnionApp.Application.Features.Results.SocialMediaResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.SocialMediaHandlers
{
    public class GetSocialMediasQueryHandler (IRepository<SocialMedia> _repository): IRequestHandler<GetSocialMediasQuery, BaseResult<List<GetSocialMediasQueryResult>>>
    {
        public async Task<BaseResult<List<GetSocialMediasQueryResult>>> Handle(GetSocialMediasQuery request, CancellationToken cancellationToken)
        {
            var social = await _repository.GetAllAsync();
            var mapped = social.Adapt<List<GetSocialMediasQueryResult>>();
            return BaseResult<List<GetSocialMediasQueryResult>>.Success(mapped);
        }
    }
}
