using Holy_locket.BLL.DTO;
using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services.Abstraction
{
    public interface IAppointmentService : IDisposable
    {
        Task DeleteAppointment(int id);
        Task UpdateAppointment(HospitalDTO hospital);
        Task CreateAppointment(HospitalDTO hospital);
        Task<HospitalDTO> GetAppointmentById(int id);
        Task<ICollection<Hospital>> GetAll();
    }
}
