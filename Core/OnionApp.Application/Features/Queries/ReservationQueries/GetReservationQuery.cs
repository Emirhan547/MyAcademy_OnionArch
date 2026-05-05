using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.ReservationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.ReservationQueries
{
    public class GetReservationQuery : IRequest<BaseResult<List<GetReservationQueryResult>>> 
    {
    }
}
