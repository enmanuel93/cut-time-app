using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Domain.Models
{
    [Table("Appointments")]
    public class Appointment
    {
        [Key]
        public int ID_Appointment { get; set; }
        public int ID_Client { get; set; }
        public int ID_Barber { get; set; }
        public DateTime Date_Time { get; set; }
        public string Service { get; set; }
        public string Notes { get; set; }

        // Relación muchos a uno con Customers
        [ForeignKey("ID_Client")]
        public Client Client { get; set; }

        // Relación muchos a uno con Barbers
        [ForeignKey("ID_Barber")]
        public Barber Barber { get; set; }
    }
}
