using System;
using System.Collections.Generic;

namespace AirTicketMiniProject.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Books = new HashSet<Book>();
        }

        public int FlightNumber { get; set; }
        public string? ArravingPoint { get; set; }
        public DateTime? DateOfArrving { get; set; }
        public string? DeparturePoint { get; set; }
        public DateTime? DateOfDeparture { get; set; }
        public TimeSpan? Timing { get; set; }
        public decimal? TicketCost { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
