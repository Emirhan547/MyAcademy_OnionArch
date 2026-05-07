using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Results
{
    public sealed class SmartPricingResult
    {
        public string Title { get; set; } = "Smart Pricing Önerisi";
        public decimal SuggestedDailyPrice { get; set; }
        public string Currency { get; set; } = "TRY";
        public string Summary { get; set; } = string.Empty;
        public List<string> PriceFactors { get; set; } = [];
        public DateTime GeneratedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
