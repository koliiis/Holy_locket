using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.DTO
{
    public class AppointmentInfoDTO
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public int PatientId { get; set; }
        public int HospitalId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSecondName { get; set; }
        public string SpecialityName { get; set; }
    }
}
