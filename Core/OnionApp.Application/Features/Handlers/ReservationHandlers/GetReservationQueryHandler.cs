using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.ReservationQueries;
using OnionApp.Application.Features.Results.ReservationResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.ReservationHandlers
{
    public class GetReservationQueryHandler (IRepository<Reservation> _repository): IRequestHandler<GetReservationQuery, BaseResult<List<GetReservationQueryResult>>>
    {
        public async Task<BaseResult<List<GetReservationQueryResult>>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return BaseResult<List<GetReservationQueryResult>>.Success(values.Adapt<List<GetReservationQueryResult>>());
        }
    }
}
