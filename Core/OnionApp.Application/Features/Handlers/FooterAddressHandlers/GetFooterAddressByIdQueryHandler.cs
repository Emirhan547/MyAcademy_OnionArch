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
    public class GetFooterAddressByIdQueryHandler (IRepository<FooterAddress> _repository): IRequestHandler<GetFooterAddressByIdQuery, BaseResult<GetFooterAddressByIdQueryResult>>
    {
        public async Task<BaseResult<GetFooterAddressByIdQueryResult>> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var footerAddress = await _repository.GetByIdAsync(request.Id);
            if (footerAddress == null)
            {
                return BaseResult<GetFooterAddressByIdQueryResult>.Fail("FooterAddress Bulunamadı");
            }
            var mapped = footerAddress.Adapt<GetFooterAddressByIdQueryResult>();
            return BaseResult<GetFooterAddressByIdQueryResult>.Success(mapped);
        }
    }
}
