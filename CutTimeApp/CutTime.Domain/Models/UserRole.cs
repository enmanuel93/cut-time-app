using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Domain.Models
{
    public class UserRole
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int User_ID { get; set; }

        [ForeignKey("Role")]
        public int Role_ID { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
