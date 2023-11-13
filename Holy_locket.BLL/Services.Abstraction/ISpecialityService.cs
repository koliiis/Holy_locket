using Holy_locket.BLL.DTO;
using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services.Abstraction
{
    public interface ISpecialityService : IDisposable
    {
        Task DeleteSpeciality(int id);
        Task UpdateSpeciality(SpecialityDTO speciality);
        Task CreateSpeciality (SpecialityDTO speciality);
        Task<SpecialityDTO> GetSpecialityById(int id);
        Task<ICollection<Speciality>> GetAll();
    }
}
