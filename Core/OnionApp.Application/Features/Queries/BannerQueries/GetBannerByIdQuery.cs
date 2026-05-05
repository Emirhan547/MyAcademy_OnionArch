using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.BannerResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.BannerQueries
{
    public class GetBannerByIdQuery(int id):IRequest<BaseResult<GetBannerByIdQueryResult>>
    {
        public int Id { get; set; } = id;
    }
}
