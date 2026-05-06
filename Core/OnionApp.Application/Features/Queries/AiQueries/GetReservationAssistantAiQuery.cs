using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Queries.AiQueries
{
    public sealed class GetReservationAssistantAiQuery : IRequest<BaseResult<AiSuggestionResult>>
    {
        public string PickUpLocation { get; set; } = string.Empty;
        public string DropOffLocation { get; set; } = string.Empty;
        public DateTime? PickUpDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string TravelNotes { get; set; } = string.Empty;
    }
}
