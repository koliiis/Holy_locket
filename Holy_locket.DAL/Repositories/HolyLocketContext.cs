using Holy_locket.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.DAL.Repositories
{
    public class HolyLocketContext : DbContext
    {
        public HolyLocketContext(DbContextOptions<HolyLocketContext> options) : base(options) 
        {
            ModelBuilder modelBuilder= new ModelBuilder();
            base.OnModelCreating(modelBuilder);
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

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-O252DHK\\SQLEXPRESS;Database=Test;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
