using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.CarResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.CarQueries
{
    public class GetLast5CarsWithBrandQuery:IRequest<BaseResult<List<GetLast5CarsWithBrandQueryResult>>>
    {
    }
}
