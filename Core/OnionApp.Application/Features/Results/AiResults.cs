using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Results
{
    public sealed class AiSuggestionResult
    {
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public List<string> Suggestions { get; set; } = [];
        public string Source { get; set; } = "LocalFallback";
        public DateTime GeneratedAtUtc { get; set; } = DateTime.UtcNow;
        public string Disclaimer { get; set; } = "Yapay zeka önerileri destek amaçlıdır; fiyat, uygunluk ve operasyon bilgilerini rezervasyon öncesi kontrol ediniz.";
    }
}
