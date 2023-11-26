using Holy_locket.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Xml.Linq;
using System.Configuration;

Console.WriteLine("123");
var contextOptions = new DbContextOptionsBuilder<HolyLocketContext>()
                .UseSqlServer(@"Server=DESKTOP-O252DHK\SQLEXPRESS;Database=Holy_LocketDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;
using var context = new HolyLocketContext(contextOptions);

context.Database.EnsureCreated();
//await specialityService.CreateSpeciality(speciality);
//await patientService.CreatePatient(patient);
//await doctorService.Add(doctor);
