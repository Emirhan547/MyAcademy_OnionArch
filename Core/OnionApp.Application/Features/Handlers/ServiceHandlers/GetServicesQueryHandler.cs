using Mapster;
using MapsterMapper;
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
    public class GetServicesQueryHandler(IRepository<Service> _repository) : IRequestHandler<GetServicesQuery, BaseResult<List<GetServicesQueryResult>>>
    {
        public async Task<BaseResult<List<GetServicesQueryResult>>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _repository.GetAllAsync();
            var mappedServices = services.Adapt<List<GetServicesQueryResult>>();
            return BaseResult<List<GetServicesQueryResult>>.Success(mappedServices);
        }
    }
}
