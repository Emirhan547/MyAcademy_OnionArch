using FluentValidation;
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
    public class GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> _repository) : IRequestHandler<GetSocialMediaByIdQuery, BaseResult<GetSocialMediaByIdQueryResult>>
    {
        public async Task<BaseResult<GetSocialMediaByIdQueryResult>> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var socials = await _repository.GetByIdAsync(request.Id);
            if (socials == null)
            {
                return BaseResult<GetSocialMediaByIdQueryResult>.Fail("Sosyal Medya bulunamadı");
            }
            var mapped = socials.Adapt<GetSocialMediaByIdQueryResult>();
            return BaseResult<GetSocialMediaByIdQueryResult>.Success(mapped);
        }
    }
}
