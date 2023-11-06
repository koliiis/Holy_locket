using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Holy_locket.DAL.Models;
using Holy_locket.BLL.DTO;

namespace Holy_locket.BLL
{
    public class ConfigurationMapper : Profile
    {
        protected ConfigurationMapper()
        {
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Hospital, HospitalDTO>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Speciality, SpecialityDTO>().ReverseMap();
        }
    }
}
