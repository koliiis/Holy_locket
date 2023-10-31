
using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.DAL.Repository
{
    public interface IDoctorRepository
    {
        List<Doctor> doctors { get; set; }
        public IEnumerable<Doctor> GetAll();
        public Doctor GetById(int id);
        public void Delete(int id);
        public void Add(Doctor doctor);
        public void Update(Doctor doctor, int id);
    }
}
