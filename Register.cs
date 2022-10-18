using System;
using System.Collections.Generic;

namespace AirTicketMiniProject.Models
{
    public partial class Register
    {
        public int Sno { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

        public virtual LoginPage? LoginPage { get; set; }
    }
}
