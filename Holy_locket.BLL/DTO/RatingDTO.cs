using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.DTO
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int Rate { get; set; }
    }
}
