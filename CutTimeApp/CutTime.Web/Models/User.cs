using System;
using System.Collections.Generic;

namespace CutTime.Web.Models
{
    public partial class User
    {
        public User()
        {
            Barbers = new HashSet<Barber>();
            Clients = new HashSet<Client>();
        }

        public int IdUser { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; }

        public virtual ICollection<Barber> Barbers { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
