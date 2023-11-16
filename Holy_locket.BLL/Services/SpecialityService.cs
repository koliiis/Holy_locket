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
    public class SpecialityService : ISpecialityService
    {
        private readonly IRepository<Speciality> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SpecialityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Speciality>();
            _mapper = mapper;
        }
        public async Task CreateSpeciality(SpecialityDTO speciality)
        {
            await _repository.Create(_mapper.Map<Speciality>(speciality)).ConfigureAwait(false);
        }
        public async Task DeleteSpeciality(int id)
        {
            await _repository.Delete(id).ConfigureAwait(false);
        }
        public async Task UpdateSpeciality(SpecialityDTO speciality)
        {
            await _repository.Update(_mapper.Map<Speciality>(speciality)).ConfigureAwait(false);

        }
        public async Task<SpecialityDTO> GetSpecialityById(int id)
        {
            var speciality = await _repository.GetById(id).ConfigureAwait(false);
            return _mapper.Map<SpecialityDTO>(speciality);
        }
        public async Task<ICollection<Speciality>> GetAll()
        {
            var specialities = await _repository.Get().ConfigureAwait(false);
            return _mapper.Map<ICollection<Speciality>>(specialities);
        }
        public void Dispose()
        {
        }
    }
}
