using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<RentACar> RentACars { get; set; }
        public IList<Reservation> PickUpReservation { get; set; }
        public IList<Reservation> DropOffReservation { get; set; }
    }
}
