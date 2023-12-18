using Holy_locket.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services.Abstraction
{
    public interface IAppointmentService : IDisposable
    {
        Task<ICollection<AppointmentDTO>> GetAllAppointments();
        Task<AppointmentDTO> GetAppointmentById(int id);
        Task DeleteAppointment(int id);
        Task SoftDeleteAppointment(int id);
        Task AddAppointment(AppointmentDTO appointment, string patientToken);
        Task UpdateAppointment(AppointmentDTO appointment);
        Task<ICollection<AppointmentInfoDTO>> GetAppointmentInfo(string token);
    }
}
