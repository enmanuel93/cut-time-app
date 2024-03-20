using System;
using System.Collections.Generic;
using CutTime.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CutTime.Web
{
    public partial class CutTimeContext : DbContext
    {
        public CutTimeContext()
        {
        }

        public CutTimeContext(DbContextOptions<CutTimeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Barber> Barbers { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:CT_Context");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.IdAppointment)
                    .HasName("PK__Appointm__CE24CCCC68B185D8");

                entity.Property(e => e.IdAppointment)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Appointment");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Time");

                entity.Property(e => e.IdBarber).HasColumnName("ID_Barber");

                entity.Property(e => e.IdClient).HasColumnName("ID_Client");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.Service)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBarberNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdBarber)
                    .HasConstraintName("FK__Appointme__ID_Ba__403A8C7D");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK__Appointme__ID_Cl__3F466844");
            });

            modelBuilder.Entity<Barber>(entity =>
            {
                entity.HasKey(e => e.IdBarber)
                    .HasName("PK__Barbers__2660521A27AE2E71");

                entity.Property(e => e.IdBarber)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Barber");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Barbers)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Barbers__ID_User__3C69FB99");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK__Clients__B5AE4EC8C3D38E9C");

                entity.Property(e => e.IdClient)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Client");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Clients__ID_User__398D8EEE");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__ED4DE442BE73B3B6");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_User");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("User_Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
