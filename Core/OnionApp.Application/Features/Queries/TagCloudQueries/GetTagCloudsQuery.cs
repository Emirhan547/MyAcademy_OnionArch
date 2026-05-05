using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.TagCloudResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.TagCloudQueries
{
    public class GetTagCloudsQuery:IRequest<BaseResult<List<GetTagCloudsQueryResult>>>
    {
    }
}
