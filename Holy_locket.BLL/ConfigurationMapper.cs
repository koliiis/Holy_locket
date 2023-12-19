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
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorDTO, Doctor>()
            .ForMember(dest => dest.Speciality, opt => opt.Ignore()) // Игнорировать отображение для Speciality
            .ForMember(dest => dest.AppointmentList, opt => opt.Ignore()) // Игнорировать отображение для AppointmentList
            .ForMember(dest => dest.RatingList, opt => opt.Ignore()) // Игнорировать отображение для RatingList
            .ForMember(dest => dest.TimesForDayList, opt => opt.Ignore()); // Игнорировать отображение для TimesForDayList
            CreateMap<Hospital, HospitalDTO>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Speciality, SpecialityDTO>().ReverseMap();
            CreateMap<Rating, RatingDTO>().ReverseMap();
            CreateMap<TimesForDay, TimesForDayDTO>().ReverseMap();
            CreateMap<TimeSlot, TimeSlotDTO>().ReverseMap();
        } 
    }
}
