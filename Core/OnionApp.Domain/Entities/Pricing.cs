using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Domain.Entities
{
    public class Pricing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<CarPricing>CarPricings { get; set; }
    }
}
