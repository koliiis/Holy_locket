using Holy_locket.BLL.DTO;
using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services.Abstraction
{
    public interface ITimeSlotsService
    {
        Task<List<List<string>>> GetTimeSlots(int doctorId);
        Task DeleteTimeSlots(int doctorId);
        Task PostTimeSlots(List<List<string>> times, int doctorId);
        Task UpdateTimeSlots(List<List<string>> times, int doctorId);
    }
}
