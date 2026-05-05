using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.CategoryResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery(int id) : IRequest<BaseResult<GetCategoryByIdQueryResult>>
    {
        public int Id { get; set; } = id;
    }
}
