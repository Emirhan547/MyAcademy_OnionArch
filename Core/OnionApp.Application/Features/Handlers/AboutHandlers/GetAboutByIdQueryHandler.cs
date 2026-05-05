using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.AboutQueries;
using OnionApp.Application.Features.Results.AboutResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler(IRepository<About> _repository) : IRequestHandler<GetAboutByIdQuery, BaseResult<GetAboutByIdQueryResult>>
    {
        public async Task<BaseResult<GetAboutByIdQueryResult>> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
           var values=await _repository.GetByIdAsync(request.Id);
           var mapped=values.Adapt<GetAboutByIdQueryResult>();
            return BaseResult<GetAboutByIdQueryResult>.Success(mapped);
        }
    }
}
