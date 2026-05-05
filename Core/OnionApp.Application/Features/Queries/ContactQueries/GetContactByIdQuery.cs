using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.ContactResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.ContactQueries
{
    public class GetContactByIdQuery(int id):IRequest<BaseResult<GetContactByIdQueryResult>>
    {
        public int Id { get; set; } = id;
    }
}
