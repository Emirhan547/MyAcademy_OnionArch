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
    public class GetBrandsQuery:IRequest<BaseResult<List<GetBrandQueryResult>>>
    {
    }
}
