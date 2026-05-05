using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.AuthorQueries;
using OnionApp.Application.Features.Results.AuthorResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.AuthorHandlers
{
    public class GetAuthorsQueryHandler(IRepository<Author> _repository) : IRequestHandler<GetAuthorsQuery, BaseResult<List<GetAuthorsQueryResult>>>
    {
        public async Task<BaseResult<List<GetAuthorsQueryResult>>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _repository.GetAllAsync();
            return BaseResult<List<GetAuthorsQueryResult>>.Success(authors.Adapt<List<GetAuthorsQueryResult>>());
        }
    }
}
