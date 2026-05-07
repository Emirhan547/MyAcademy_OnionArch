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
    public sealed class GetSmartPricingAiQuery : IRequest<BaseResult<SmartPricingResult>>
    {
        public string CarType { get; set; } = string.Empty;
        public string Season { get; set; } = "normal";
        public string Location { get; set; } = string.Empty;
        public int Km { get; set; }
        public string Fuel { get; set; } = string.Empty;
        public int HistoricalDemandIndex { get; set; } = 50;
    }
}
