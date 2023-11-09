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
            DoctorService doctorService = new DoctorService(mapper, unitOfWork);
            SpecialityService specialityService = new SpecialityService(unitOfWork, mapper); 
            context.Database.EnsureCreated();
            PatientDTO patient = new PatientDTO();
            patient.Birthday = DateTime.Now;
            patient.FirstName = "Test";
            patient.Phone = "1233123";
            patient.SecondName = "Test";
            patient.Email = "Test";
            DoctorDTO doctor = new DoctorDTO();
            doctor.FirstName = "Валерій";
            doctor.Phone = "14871478";
            doctor.SecondName = "Бебренко";
            doctor.Description = "Жме сотку, а ти жмеш?????";
            doctor.Photo = "";
            doctor.SpecialityId = 1;
            doctor.Experience = 15;
            SpecialityDTO speciality = new SpecialityDTO();
            speciality.Name = "Проктолог";
            //await specialityService.CreateSpeciality(speciality);
            //await patientService.CreatePatient(patient);
            await doctorService.Add(doctor);

        }
    }
}
