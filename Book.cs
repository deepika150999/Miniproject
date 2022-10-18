using System;
using System.Collections.Generic;

namespace AirTicketMiniProject.Models
{
    public partial class Book
    {
        public Book()
        {
            Passengers = new HashSet<Passenger>();
            Payments = new HashSet<Payment>();
        }

        public int BookingId { get; set; }
        public int? FlightNumber { get; set; }
        public DateTime? DateofBooking { get; set; }
        public string? ClassType { get; set; }
        public int? NumberOfPassengers { get; set; }

        public virtual Flight? FlightNumberNavigation { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
