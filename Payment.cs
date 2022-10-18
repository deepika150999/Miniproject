using System;
using System.Collections.Generic;

namespace AirTicketMiniProject.Models
{
    public partial class Payment
    {
        public int Paymentid { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int TransactionId { get; set; }
        public int? BookingId { get; set; }
        public string? PaymentMode { get; set; }

        public virtual Book? Booking { get; set; }
    }
}
