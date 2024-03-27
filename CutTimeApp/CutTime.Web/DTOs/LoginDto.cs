using CutTime.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Web.DTOs
{
    public class LoginDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Role> Roles { get; set; }
    }
}
