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
        public DoctorService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _doctorRepository = _unitOfWork.GetRepository<Doctor>();
            _mapper = mapper;
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
            return _mapper.Map<ICollection<DoctorDTO>>(doctors);
        }
        public async Task<DoctorDTO> GetDoctorById(int id)
        {
            var doctor = await _doctorRepository.Get(id).ConfigureAwait(false);
            return _mapper.Map<DoctorDTO>(doctor);
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
