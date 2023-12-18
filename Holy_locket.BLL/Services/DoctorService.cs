using AutoMapper;
using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Abstracts;
using Holy_locket.DAL.Models;
using Microsoft.Extensions.Configuration;
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
        private readonly ISpecialityService _specialityService;
        IConfiguration _config;
        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper, ISpecialityService specialityService, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _doctorRepository = _unitOfWork.GetRepository<Doctor>();
            _mapper = mapper;
            _specialityService = specialityService;
            _config = config;
        }
        public async Task<DoctorDTO> MapSpeciality(DoctorDTO doctor)
        {
            var speciality = await _specialityService.GetSpecialityById(doctor.SpecialityId);
            doctor.SpecialityName = speciality.Name;
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
                var speciality = await _specialityService.GetSpecialityById(doctor.SpecialityId);
                doctor.SpecialityName = speciality.Name;
            }
            return doctorDTOs;
        }
        public async Task<DoctorDTO> GetDoctorById(int id)
        {
            var doctor = await _doctorRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map<DoctorDTO>(doctor);
            return await MapSpeciality(dto);
        }
        public async Task UpdateDoctor(DoctorDTO doctor)
        {
            await _doctorRepository.Update(_mapper.Map<Doctor>(doctor)).ConfigureAwait(false);
        }
        public async Task<IEnumerable<DoctorDTO>> GetFiltered(string token, int minimumExpirience = 0, string? specialityName = null, string? gender = null, double rating = 0)
        {
            var result = await AuthService.GetFromToken(token).ConfigureAwait(false);
            if (result?.Id != 0 && result?.Role == 1 && await AuthService.CheckToken(_config, token).ConfigureAwait(false))
            {
                var doctors = await _doctorRepository.Get().ConfigureAwait(false);
                    var doctorDTOs = _mapper.Map<ICollection<DoctorDTO>>(doctors);
                    foreach (var doctor in doctorDTOs)
                    {
                        var speciality = await _specialityService.GetSpecialityById(doctor.SpecialityId);
                        doctor.SpecialityName = speciality.Name;
                    }
                    var filteredList = doctorDTOs
                        .Where(doctor =>
                            (specialityName == null || doctor.SpecialityName == specialityName) &&
                            (gender == null || doctor.Gender == gender) &&
                            (minimumExpirience == 0 || doctor.Experience > minimumExpirience) &&
                            (rating == 0 || doctor.Rating > rating)
                        );

                    return filteredList;
            }
            else
                return null;
        }
        public async Task<DoctorDTO> GetDoctor(string token)
        {
            var result = await AuthService.GetFromToken(token).ConfigureAwait(false);
            if (result?.Id != 0 && result?.Role == 2 && await AuthService.CheckToken(_config, token).ConfigureAwait(false))
            {
                var doctor = await _doctorRepository.GetById(result.Id).ConfigureAwait(false);
                    return await MapSpeciality(_mapper.Map<DoctorDTO>(doctor));
            }
            else
                return null;
        }
        public void Dispose()
        {
        }

    }
}
