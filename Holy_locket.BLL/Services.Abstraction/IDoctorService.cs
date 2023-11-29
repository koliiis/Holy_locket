using Holy_locket.BLL.DTO;
using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services.Abstraction
{
    public interface IDoctorService : IDisposable
    {
        Task<ICollection<DoctorDTO>> GetAllDoctors();
        Task<DoctorDTO> GetDoctorById(int id);
        Task DeleteDoctor(int id);
        Task AddDoctor(DoctorDTO doctor);
        Task UpdateDoctor(DoctorDTO doctor);
        Task<IEnumerable<DoctorDTO>> GetFiltered(int minimumExpirience, int specialityId, string gender);
    }
}
