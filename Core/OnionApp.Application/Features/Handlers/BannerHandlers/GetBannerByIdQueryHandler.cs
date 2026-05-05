using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.BannerQueries;
using OnionApp.Application.Features.Results.BannerResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler (IRepository<Banner>_repository): IRequestHandler<GetBannerByIdQuery, BaseResult<GetBannerByIdQueryResult>>
    {
        public async Task<BaseResult<GetBannerByIdQueryResult>> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
           var values=await _repository.GetByIdAsync(request.Id);
            if (values != null) 
            {
                return BaseResult<GetBannerByIdQueryResult>.Fail("Ürün Bulunamadı");
            }
            var mapped=values.Adapt<GetBannerByIdQueryResult>();
            return BaseResult<GetBannerByIdQueryResult>.Success(mapped); 

        }
    }
}
