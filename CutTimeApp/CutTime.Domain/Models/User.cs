using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CutTime.Domain.Models
{
    public class User
    {
        public int ID_User { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public string PasswordConfirmed { get; set; }

        public DateTime Registration_Date { get; set; }
        public List<Role> Roles { get; set; }
        public UserType UserType { get; set; }
    }
}
