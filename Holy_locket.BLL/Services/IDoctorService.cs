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
        public Task<ICollection<Doctor>> GetAll();
        public Task<Doctor> GetById(int id);
        public Task Delete(int id);
        public Task Add(Doctor doctor);
        public Task Update(Doctor doctor);
    }
}
