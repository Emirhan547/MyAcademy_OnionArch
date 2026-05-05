using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.ServiceQueries;
using OnionApp.Application.Features.Results.ServiceResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler (IRepository<Service> _repository): IRequestHandler<GetServiceByIdQuery, BaseResult<GetServiceByIdQueryResult>>
    {
        public async Task<BaseResult<GetServiceByIdQueryResult>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var services=await _repository.GetByIdAsync(request.Id);
            if(services == null)
            {
                return BaseResult<GetServiceByIdQueryResult>.Fail("Services Bulunamadı");
            }
            var mapped = services.Adapt<GetServiceByIdQueryResult>();
            return BaseResult<GetServiceByIdQueryResult>.Success(mapped);
        }
    }
}
