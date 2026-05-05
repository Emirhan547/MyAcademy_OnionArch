using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.ViewModels
{
    public class CarPricingViewModel
    {
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string Brand { get; set; }

        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
    }
}
