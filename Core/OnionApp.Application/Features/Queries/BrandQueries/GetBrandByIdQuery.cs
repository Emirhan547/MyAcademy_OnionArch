using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.BrandResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.BrandQueries
{
    public class GetBrandByIdQuery(int id):IRequest<BaseResult<GetBrandByIdQueryResult>>
    {
        public int Id { get; set; } = id;
    }
}
