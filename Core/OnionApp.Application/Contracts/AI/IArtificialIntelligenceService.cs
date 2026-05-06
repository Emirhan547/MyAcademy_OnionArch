using OnionApp.Application.Features.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Contracts.AI
{
    public interface IArtificialIntelligenceService
    {
        Task<AiSuggestionResult> GenerateSuggestionAsync(AiPromptRequest request, CancellationToken cancellationToken = default);
    }
}
