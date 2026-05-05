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
    public class GetContactByIdQueryHandler (IRepository<Contact> _repository): IRequestHandler<GetContactByIdQuery, BaseResult<GetContactByIdQueryResult>>
    {
        public async Task<BaseResult<GetContactByIdQueryResult>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetByIdAsync(request.Id);
            if(contact == null)
            {
                return BaseResult<GetContactByIdQueryResult>.Fail("Contact Bulunamadı");
            }
            var mapped=contact.Adapt<GetContactByIdQueryResult>();
            return BaseResult<GetContactByIdQueryResult>.Success(mapped);
        }
    }
}
