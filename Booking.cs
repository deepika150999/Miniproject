using System;
using System.Collections.Generic;

namespace AirTicketMiniProject.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Payments = new HashSet<Payment>();
        }

        public int BookingId { get; set; }
        public int? FlightNumber { get; set; }
        public string? PassangerName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? Pincode { get; set; }
        public string? ContactNumber { get; set; }
        public string? ClassType { get; set; }
        public int? NumberOfPassengers { get; set; }

        public virtual Flight? FlightNumberNavigation { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
