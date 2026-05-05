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
    public class GetSocialMediaByIdQuery:IRequest<BaseResult<GetSocialMediaByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetSocialMediaByIdQuery(int id)
        {
            Id = id;
        }
    }
}
