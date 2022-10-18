using System;
using System.Collections.Generic;

namespace AirTicketMiniProject.Models
{
    public partial class Passenger
    {
        public int Pid { get; set; }
        public int? BookingId { get; set; }
        public string? PassangerName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? Pincode { get; set; }
        public string? ContactNumber { get; set; }

        public virtual Book? Booking { get; set; }
    }
}
