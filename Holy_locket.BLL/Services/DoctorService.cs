using Holy_locket.DAL.Abstracts;
using Holy_locket.DAL.Models;
using Holy_locket.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services
{
    public class DoctorService : IDoctorService
    {
        public IRepository<Doctor> _doctorRepository;
        public DoctorService(IRepository<Doctor> Repository) 
        {
            _doctorRepository = Repository;
           
        }
        public async Task Add(Doctor doctor)
        {
            await _doctorRepository.Create(doctor);
        }
        public async Task Delete(int id)
        {
            await _doctorRepository.Delete(id);
        }
        public async Task<ICollection<Doctor>> GetAll()
        {
            return await _doctorRepository.Get();  
        }
        public async Task<Doctor> GetById(int id)
        {
            return await _doctorRepository.Get(id);
        }
        public async Task Update(Doctor doctor)
        {
            await _doctorRepository.Update(doctor);
        }

    }
}
