using AutoMapper;
using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Abstracts;
using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> _doctorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SpecialityService specialityService;
        public DoctorService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _doctorRepository = _unitOfWork.GetRepository<Doctor>();
            _mapper = mapper;
            specialityService = new SpecialityService(_unitOfWork, _mapper);
        }
        public async Task<DoctorDTO> MapSpeciality(DoctorDTO doctor)
        {
            var speciality = specialityService.GetSpecialityById(doctor.SpecialityId);
            doctor.SpecialityName = speciality.Result.Name;
            return doctor;
        }
        public async Task AddDoctor(DoctorDTO doctor)
        {
            await _doctorRepository.Create(_mapper.Map<Doctor>(doctor)).ConfigureAwait(false);
        }
        public async Task DeleteDoctor(int id)
        {
            await _doctorRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<DoctorDTO>> GetAllDoctors()
        {
            var doctors = await _doctorRepository.Get().ConfigureAwait(false);
            var doctorDTOs = _mapper.Map<ICollection<DoctorDTO>>(doctors);
            foreach (var doctor in doctorDTOs) 
            {
                var speciality = specialityService.GetSpecialityById(doctor.SpecialityId);
                doctor.SpecialityName = speciality.Result.Name;
            }
            return doctorDTOs;
        }
        public async Task<DoctorDTO> GetDoctorById(int id)
        {
            var doctor = await _doctorRepository.GetById(id).ConfigureAwait(false);
            var dto =_mapper.Map<DoctorDTO>(doctor);
            return MapSpeciality(dto).Result;
        }
        public async Task UpdateDoctor(DoctorDTO doctor)
        {
            await _doctorRepository.Update(_mapper.Map<Doctor>(doctor)).ConfigureAwait(false);
        }
        public void Dispose()
        {
        }
    }
}
