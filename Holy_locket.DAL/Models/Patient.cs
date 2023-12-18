using Holy_locket.DAL.Abstracts;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.DAL.Models
{
    public class Patient : User
    {
        [NotMapped]
        public ICollection<Appointment>? AppointmentList { get; set; }
        [NotMapped]
        public ICollection<Rating> RatingList { get; set; }
        public override int Role { get; set; } = 1;
    }
}
