using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Domain.Models
{
    [Table("User_Role")]
    public class UserRole
    {
        [Key]
        public int ID { get; set; }
        
        public int ID_User { get; set; }
        
        public int ID_Role { get; set; }

        [ForeignKey("ID_User")]
        public User User { get; set; }

        [ForeignKey("ID_Role")]
        public Role Role { get; set; }
    }
}
