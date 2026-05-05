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
    public class GetAuthorByIdQueryHandler (IRepository<Author> _repository): IRequestHandler<GetAuthorByIdQuery, BaseResult<GetAuthorByIdQueryResult>>
    {
        public async Task<BaseResult<GetAuthorByIdQueryResult>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);
            if (author == null)
            {
                return BaseResult<GetAuthorByIdQueryResult>.Fail("Author Bulunamadı");
            }
            return BaseResult<GetAuthorByIdQueryResult>.Success(author.Adapt<GetAuthorByIdQueryResult>());
        }
    }
}
