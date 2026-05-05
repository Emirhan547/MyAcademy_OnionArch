using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Commands.ReservationCommands
{
    public class UpdateReservationCheckInCommand:IRequest
    {
        public int ReservationId { get; set; }
        public int EndKilometer { get; set; }
        public int EndFuelLevel { get; set; }
        public string? CheckInDamageNote { get; set; }
        public decimal ExtraChargeAmount { get; set; }
    }
}
