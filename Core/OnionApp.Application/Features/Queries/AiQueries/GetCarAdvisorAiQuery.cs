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
    public sealed class GetCarAdvisorAiQuery : IRequest<BaseResult<AiSuggestionResult>>
    {
        public string TripPurpose { get; set; } = string.Empty;
        public int PassengerCount { get; set; }
        public decimal? DailyBudget { get; set; }
        public string PreferredFuel { get; set; } = string.Empty;
        public string PreferredTransmission { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
