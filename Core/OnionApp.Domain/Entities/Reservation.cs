using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? PickUpLocationId { get; set; }
        public int? DropOffLocationId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string? Description { get; set; }
        public Location PickUpLocation { get; set; }
        public Location DropOffLocation { get; set; }
        public string Status { get; set; }

        public DateTime? PickUpDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public int? StartKilometer { get; set; }
        public int? EndKilometer { get; set; }
        public int? StartFuelLevel { get; set; }
        public int? EndFuelLevel { get; set; }

        public string? CheckOutDamageNote { get; set; }
        public string? CheckInDamageNote { get; set; }
        public decimal ExtraChargeAmount { get; set; }

        public DateTime? CheckOutAt { get; set; }
        public DateTime? CheckInAt { get; set; }
    }
}
