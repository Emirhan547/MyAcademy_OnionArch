using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.AI.Models
{
    public sealed record PriceSuggestionResult(
    string City,
    string CarSegment,
    DateOnly PickupDate,
    DateOnly ReturnDate,
    decimal SuggestedMinPrice,
    decimal SuggestedMaxPrice,
    bool IsOpportunity,
    string ModelVersion);
}
