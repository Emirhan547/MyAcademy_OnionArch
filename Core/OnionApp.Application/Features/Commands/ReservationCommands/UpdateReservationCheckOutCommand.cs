using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Commands.ReservationCommands
{
    public class UpdateReservationCheckOutCommand:IRequest
    {
        public int ReservationId { get; set; }
        public int StartKilometer { get; set; }
        public int StartFuelLevel { get; set; }
        public string? CheckOutDamageNote { get; set; }
    }
}
