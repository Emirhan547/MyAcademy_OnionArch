using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.StatisticsQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.StatisticsHandlers
{
    public class GetAuthorCountQueryHandler
    : IRequestHandler<GetAuthorCountQuery, BaseResult<int>>
    {
        private readonly IStatisticsRepository _repository;

        public GetAuthorCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResult<int>> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
        {
            var result =await _repository.GetAuthorCount();

            return BaseResult<int>.Success(result);
        }
    }
}
