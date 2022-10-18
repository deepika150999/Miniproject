using System;
using System.Collections.Generic;

namespace AirTicketMiniProject.Models
{
    public partial class EconomyClass
    {
        public int EconomyClsId { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
    }
}
