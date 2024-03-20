using System;
using System.Collections.Generic;

namespace CutTime.Web.Models
{
    public partial class Appointment
    {
        public int IdAppointment { get; set; }
        public int? IdClient { get; set; }
        public int? IdBarber { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Service { get; set; }
        public string? Notes { get; set; }

        public virtual Barber? IdBarberNavigation { get; set; }
        public virtual Client? IdClientNavigation { get; set; }
    }
}
