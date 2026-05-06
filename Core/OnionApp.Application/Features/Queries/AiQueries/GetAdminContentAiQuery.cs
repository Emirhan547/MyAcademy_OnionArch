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
    public sealed class GetAdminContentAiQuery : IRequest<BaseResult<AiSuggestionResult>>
    {
        public string ContentType { get; set; } = string.Empty;
        public string TargetAudience { get; set; } = string.Empty;
        public string Keywords { get; set; } = string.Empty;
        public string ToneOfVoice { get; set; } = string.Empty;
    }
}
