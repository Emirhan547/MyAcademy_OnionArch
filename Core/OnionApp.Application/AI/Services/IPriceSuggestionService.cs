using OnionApp.Application.AI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.AI.Services
{
    public interface IPriceSuggestionService
    {
        Task<PriceSuggestionResult> SuggestAsync(string city, string carSegment, DateOnly pickupDate, DateOnly returnDate, CancellationToken cancellationToken = default);
    }
}
