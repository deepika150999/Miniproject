using System;
using System.Collections.Generic;

namespace AirTicketMiniProject.Models
{
    public partial class LoginPage
    {
        public string EmailId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public int Sno { get; set; }

        public virtual Register SnoNavigation { get; set; } = null!;
    }
}
