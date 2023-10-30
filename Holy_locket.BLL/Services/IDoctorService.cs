using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services
{
    public interface IDoctorService
    {
        public IEnumerable<Doctor> GetAll();
        public Doctor GetById(int id);
        public void Delete(int id);
        public void Add(Doctor doctor);
        public void Update(Doctor doctor, int id);
    }
}
