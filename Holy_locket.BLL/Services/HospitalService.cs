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
    public class HospitalService : IHospitalService
    {
        private readonly IRepository<Hospital> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HospitalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Hospital>();
            _mapper = mapper;
        }
        public async Task CreateHospital(HospitalDTO hospital)
        {
            await _repository.Create(_mapper.Map<Hospital>(hospital)).ConfigureAwait(false);
        }
        public async Task DeleteHospital(int id)
        {
            await _repository.Delete(id).ConfigureAwait(false);
        }
        public async Task UpdateHospital(HospitalDTO hospital)
        {
            await _repository.Update(_mapper.Map<Hospital>(hospital)).ConfigureAwait(false);

        }
        public async Task<HospitalDTO> GetHospitalById(int id)
        {
            var hospital = await _repository.Get(id).ConfigureAwait(false);
            return _mapper.Map<HospitalDTO>(hospital);
        }
        public async Task<ICollection<Hospital>> GetAll()
        {
            var hospitals = await _repository.Get().ConfigureAwait(false);
            return _mapper.Map<ICollection<Hospital>>(hospitals);
        }
        public void Dispose()
        {
        }
    }
}
