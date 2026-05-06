using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Contracts.AI
{
    public sealed class AiPromptRequest
    {
        public string UseCase { get; set; } = string.Empty;
        public string SystemPrompt { get; set; } = string.Empty;
        public string UserPrompt { get; set; } = string.Empty;
        public string FallbackTitle { get; set; } = string.Empty;
        public IReadOnlyList<string> FallbackSuggestions { get; set; } = [];
    }
}
