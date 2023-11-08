using AutoMapper;
using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL
{
    public class Test
    {
        public Test()
        {
        }

        public async void Start()
        {
            var contextOptions = new DbContextOptionsBuilder<HolyLocketContext>()
                .UseSqlServer(@"Server=DESKTOP-K7HFUB0\HOLY_LOCKET;Database=Holy_LocketDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;
            using var context = new HolyLocketContext(contextOptions);
            IMapper mapper = new MapperConfiguration(c => c.AddProfile<ConfigurationMapper>()).CreateMapper();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            PatientService patientService = new PatientService(unitOfWork, mapper);
            context.Database.EnsureCreated();
            PatientDTO patient = new PatientDTO();
            patient.Birthday = DateTime.Now;
            patient.FirstName = "Test";
            patient.Phone = "1233123";
            patient.SecondName = "Test";
            patient.Email = "Test";
            await  patientService.CreatePatient(patient);
        }
    }
}
