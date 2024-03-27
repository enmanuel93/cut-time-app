using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Domain.Models
{
    public class UserType
    {
        [Key]
        public int ID_UserType { get; set; }
        public string Type { get; set; }
    }
}
