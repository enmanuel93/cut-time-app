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
        public CutTimeContext(DbContextOptions<CutTimeContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Client)
                .WithOne(c => c.User)
                .HasForeignKey<Client>(c => c.ID_User);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Barber)
                .WithOne(b => b.User)
                .HasForeignKey<Barber>(b => b.ID_User);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Appointments)
                .WithOne(a => a.Client)
                .HasForeignKey(a => a.ID_Customer);

            modelBuilder.Entity<Barber>()
                .HasMany(b => b.Appointments)
                .WithOne(a => a.Barber)
                .HasForeignKey(a => a.ID_Barber);
        }
    }
}
