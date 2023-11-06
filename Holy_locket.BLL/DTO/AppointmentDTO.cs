using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.DTO
{
    internal class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int HospitalId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
