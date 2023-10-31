using Holy_locket.DAL.Repository;
using ModelsLibrary;
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
        public void Add(Doctor doctor)
        {
            _doctorRepository.Add(doctor);
        }

        public void Delete(int id)
        {
            _doctorRepository.Delete(id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();  
        }

        public Doctor GetById(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public void Update(Doctor doctor, int id)
        {
            _doctorRepository.Update(doctor,id);
        }
    }
}
