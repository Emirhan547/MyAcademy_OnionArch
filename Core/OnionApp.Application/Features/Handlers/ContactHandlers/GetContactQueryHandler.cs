using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.ContactQueries;
using OnionApp.Application.Features.Results.ContactResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.ContactHandlers
{
    public class GetContactQueryHandler(IRepository<Contact> _repository) : IRequestHandler<GetContactQuery, BaseResult<List<GetContactQueryResults>>>
    {


        public async Task<BaseResult<List<GetContactQueryResults>>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _repository.GetAllAsync();
            var response = contacts.Adapt<List<GetContactQueryResults>>();
            return BaseResult<List<GetContactQueryResults>>.Success(response);
        }
    }
}
