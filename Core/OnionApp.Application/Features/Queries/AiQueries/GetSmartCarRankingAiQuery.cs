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
    public sealed class GetSmartCarRankingAiQuery : IRequest<BaseResult<AiSuggestionResult>>
    {
        public int LocationId { get; set; }
        public string City { get; set; } = string.Empty;
        public string Segment { get; set; } = string.Empty;
        public string TripPurpose { get; set; } = string.Empty;
        public int PassengerCount { get; set; } = 2;
        public decimal? DailyBudget { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}