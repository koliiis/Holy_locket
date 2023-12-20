using Holy_locket.DAL.Migrations;
using Holy_locket.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.DAL.Repositories
{
    public class HolyLocketContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=holly-db;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speciality>()
                    .HasMany(s => s.DoctorList)
                    .WithOne(d => d.Speciality)
                    .HasForeignKey(d => d.SpecialityId)
                    .IsRequired();
            modelBuilder.Entity<Doctor>()
                   .HasMany(d => d.AppointmentList)
                   .WithOne(a => a.Doctor)
                   .HasForeignKey(a => a.DoctorId)
                   .IsRequired();
            modelBuilder.Entity<Doctor>()
                   .HasMany(a => a.RatingList)
                   .WithOne(a => a.Doctor)
                   .HasForeignKey(a => a.DoctorId)
                   .IsRequired();
            modelBuilder.Entity<Doctor>()
                  .HasMany(a => a.TimesForDayList)
                  .WithOne(a => a.Doctor)
                  .HasForeignKey(a => a.DoctorId)
                  .IsRequired();
            modelBuilder.Entity<Hospital>()
                   .HasMany(h => h.AppointmentList)
                   .WithOne(a => a.Hospital)
                   .HasForeignKey(a => a.HospitalId)
                   .IsRequired();
            modelBuilder.Entity<Patient>()
                   .HasMany(p => p.AppointmentList)
                   .WithOne(a => a.Patient)
                   .HasForeignKey(a => a.PatientId)
                   .IsRequired();
            modelBuilder.Entity<Patient>()
                   .HasMany(p => p.RatingList)
                   .WithOne(a => a.Patient)
                   .HasForeignKey(a => a.PatientId)
                   .IsRequired();
            modelBuilder.Entity<TimesForDay>()
                   .HasMany(a => a.TimeSlotList)
                   .WithOne(a => a.TimesForDay)
                   .HasForeignKey(a => a.TimesForDayId)
                   .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<TimesForDay> TimesForDays { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

    }
}
