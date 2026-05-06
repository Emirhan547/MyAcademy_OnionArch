using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Persistence.ArtificialIntelligence
{
    public sealed class AiSettings
    {
        public string Provider { get; set; } = "LocalFallback";
        public string ApiKey { get; set; } = string.Empty;
        public string Endpoint { get; set; } = "https://api.openai.com/v1/chat/completions";
        public string Model { get; set; } = "gpt-4o-mini";
        public int MaxTokens { get; set; } = 700;
        public double Temperature { get; set; } = 0.4;
    }
}
