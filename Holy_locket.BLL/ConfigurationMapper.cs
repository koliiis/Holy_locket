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
        private readonly IRepository<Speciality> _specialityRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ConfigurationMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _specialityRepository = unitOfWork.GetRepository<Speciality>();
             
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Doctor, DoctorDTO>()
                .ForMember(dest => dest.SpecialityName, opt => opt.MapFrom(src => (_specialityRepository.Get(s => s.Id == src.SpecialityId)).Result.FirstOrDefault()));
            CreateMap<Hospital, HospitalDTO>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Speciality, SpecialityDTO>().ReverseMap();
        } 
    }
}
