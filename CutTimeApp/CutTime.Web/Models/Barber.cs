using System;
using System.Collections.Generic;

namespace CutTime.Web.Models
{
    public partial class Barber
    {
        public Barber()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int IdBarber { get; set; }
        public int? IdUser { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
