using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.SocialMediaResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.SocialMediaQueries
{
    public class GetSocialMediasQuery:IRequest<BaseResult<List<GetSocialMediasQueryResult>>>
    {
    }
}
