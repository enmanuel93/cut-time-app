using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CutTime.Domain.Models
{
    public class User
    {
        [Key]
        public int ID_User { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string User_Type { get; set; }

        // Relación uno a uno con Customers
        public Client Client { get; set; }

        // Relación uno a uno con Barbers
        public Barber Barber { get; set; }
    }
}
