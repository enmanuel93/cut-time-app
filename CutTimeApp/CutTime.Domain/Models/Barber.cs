using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Domain.Models
{
    public class Barber
    {
        [Key]
        public int ID_Barber { get; set; }
        public int ID_User { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Relación uno a uno con User
        [ForeignKey("ID_User")]
        public User User { get; set; }

        // Relación uno a muchos con Appointments
        public List<Appointment> Appointments { get; set; }
    }
}
