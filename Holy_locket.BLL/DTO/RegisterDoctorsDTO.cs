using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.DTO
{
    public class RegisterDoctorsDTO
    {
        public DoctorDTO Doctor { get; set; }
        public List<List<string>> Times { get; set; }

    }
}
