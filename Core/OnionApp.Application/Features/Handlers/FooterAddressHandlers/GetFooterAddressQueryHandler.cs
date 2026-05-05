using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.FooterAddressQueries;
using OnionApp.Application.Features.Results.FooterAddressResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler(IRepository<FooterAddress> _repository) : IRequestHandler<GetFooterAddressQuery, BaseResult<List<GetFooterAddressQueryResult>>>
    {
        public async Task<BaseResult<List<GetFooterAddressQueryResult>>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var footerAddress = await _repository.GetAllAsync();
            var mapped = footerAddress.Adapt<List<GetFooterAddressQueryResult>>();
            return BaseResult<List<GetFooterAddressQueryResult>>.Success(mapped);
        }
    }
}
