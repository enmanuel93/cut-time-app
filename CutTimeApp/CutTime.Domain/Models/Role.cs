using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Domain.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public int ID_Role { get; set; }
        public string Name { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
