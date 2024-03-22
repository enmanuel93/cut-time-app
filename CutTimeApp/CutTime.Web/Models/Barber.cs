using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        [DisplayName("Nombres")]
        public string? Name { get; set; }

        [DisplayName("Apellidos")]
        public string? Lastname { get; set; }

        [DisplayName("Correo")]
        public string? Email { get; set; }

        [DisplayName("Telefono")]
        public string? Phone { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
