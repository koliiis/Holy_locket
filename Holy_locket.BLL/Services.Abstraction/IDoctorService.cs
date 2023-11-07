using Holy_locket.BLL.DTO;
using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services.Abstraction
{
    public interface IDoctorService
    {
        public Task<ICollection<DoctorDTO>> GetAll();
        public Task<DoctorDTO> GetById(int id);
        public Task Delete(int id);
        public Task Add(DoctorDTO doctor);
        public Task Update(DoctorDTO doctor);
    }
}
