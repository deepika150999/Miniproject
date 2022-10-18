using System;
using System.Collections.Generic;

namespace AirTicketMiniProject.Models
{
    public partial class Class
    {
        public Class()
        {
            BusinessClasses = new HashSet<BusinessClass>();
            EconomyClasses = new HashSet<EconomyClass>();
        }

        public int ClassId { get; set; }
        public int? EconomyClsId { get; set; }
        public int? BusinessclsId { get; set; }

        public virtual ICollection<BusinessClass> BusinessClasses { get; set; }
        public virtual ICollection<EconomyClass> EconomyClasses { get; set; }
    }
}
