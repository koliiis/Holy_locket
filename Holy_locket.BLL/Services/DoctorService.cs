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
        public IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository) 
        {
            _doctorRepository= doctorRepository;
           
        }
        public void Add(Doctors doctor)
        {
            _doctorRepository.Add(doctor);
        }

        public void Delete(int id)
        {
            _doctorRepository.Delete(id);
        }

        public IEnumerable<Doctors> GetAll()
        {
            return _doctorRepository.GetAll();  
        }

        public Doctors GetById(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public void Update(Doctors doctor, int id)
        {
            _doctorRepository.Update(doctor,id);
        }
    }
}
