using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.FooterAddressResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery:IRequest<BaseResult<List<GetFooterAddressQueryResult>>>
    {
    }
}
