using FluentValidation;
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
    public class GetAboutQueryHandler(IRepository<About> _repository) : IRequestHandler<GetAboutsQuery, BaseResult<List<GetAboutsQueryResult>>>
    {
        public async Task<BaseResult<List<GetAboutsQueryResult>>> Handle(GetAboutsQuery request, CancellationToken cancellationToken)
        {
            var abouts = await _repository.GetAllAsync();
            var mapped = abouts.Adapt<List<GetAboutsQueryResult>>(); 
            return BaseResult<List<GetAboutsQueryResult>>.Success(mapped);
        }
    }
}
