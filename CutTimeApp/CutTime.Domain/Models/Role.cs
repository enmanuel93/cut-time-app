using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Domain.Models
{
    public class Role
    {
        public int ID_Role { get; set; }
        public string Name { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
