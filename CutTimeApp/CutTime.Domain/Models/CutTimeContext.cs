using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Domain.Models
{
    public class CutTimeContext: DbContext
    {

        public DbSet<User>? Users { get; set; }

        public DbSet<Client>? Clients { get; set; }

        public DbSet<Barber>? Barbers { get; set; }

        public DbSet<Appointment>? Appointments { get; set; }

        public CutTimeContext(DbContextOptions<CutTimeContext> options) : base(options) { }

    }

}
