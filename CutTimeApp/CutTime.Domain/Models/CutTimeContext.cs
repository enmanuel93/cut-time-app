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
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();

            modelBuilder.Entity<UserRole>()
                .HasKey(c => new { c.ID_Role, c.ID_User });

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Appointments)
                .WithOne(a => a.Client)
                .HasForeignKey(a => a.ID_Client);

            modelBuilder.Entity<Barber>()
                .HasMany(b => b.Appointments)
                .WithOne(a => a.Barber)
                .HasForeignKey(a => a.ID_Barber);

            modelBuilder.Entity<Appointment>()
                .HasOne(b => b.Barber)
                .WithMany(c => c.Appointments)
                .HasForeignKey(b => b.ID_Barber);

            modelBuilder.Entity<Appointment>()
                .HasOne(c => c.Client)
                .WithMany(c => c.Appointments)
                .HasForeignKey(c => c.ID_Client);
        }
    }
}
