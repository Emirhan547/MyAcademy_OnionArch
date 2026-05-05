using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.CarDescriptionQueries;
using OnionApp.Application.Features.Results.CarDescriptionResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionQueryHandler(ICarDescriptionRepository _repository) : IRequestHandler<GetCarDescriptionByCarIdQuery, BaseResult<GetCarDescriptionQueryResult>>
    {
        public async Task<BaseResult<GetCarDescriptionQueryResult>> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var result =await  _repository.GetCarDescription(request.Id);
            if (result == null)
            {
                return BaseResult<GetCarDescriptionQueryResult>.Fail("Bulunmaadı");
            }
            return BaseResult<GetCarDescriptionQueryResult>.Success(result.Adapt<GetCarDescriptionQueryResult>());
        }
    }
}
