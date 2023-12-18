using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Holy_locket.DAL.Models;
using Holy_locket.BLL.DTO;
using Holy_locket.DAL.Abstracts;

namespace Holy_locket.BLL
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper()
        {    
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentInfoDTO>().ReverseMap();
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Hospital, HospitalDTO>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Speciality, SpecialityDTO>().ReverseMap();
            CreateMap<Rating, RatingDTO>().ReverseMap();
        } 
    }
}
