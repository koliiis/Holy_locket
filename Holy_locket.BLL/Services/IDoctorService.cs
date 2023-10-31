using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services
{
    public interface IDoctorService
    {
        public IEnumerable<Doctors> GetAll();
        public Doctors GetById(int id);
        public void Delete(int id);
        public void Add(Doctors doctor);
        public void Update(Doctors doctor, int id);
    }
}
