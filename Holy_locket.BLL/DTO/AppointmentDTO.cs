using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.DTO
{
    public class AppointmentDTO : IComparable<AppointmentDTO>
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public int HospitalId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public int CompareTo(AppointmentDTO? b)
        {
            DateTime d1 = DateTime.Parse(this.Date);
            DateTime d2 = DateTime.Parse(b.Date);

            if (this.Date == b.Date && this.Time == b.Time)
                return 0;

            else if (d1 > d2 || (d1 == d2 && this.Time.CompareTo(b.Time) > 0))
                return 1;
            else
                return -1;
        }
    }
}
