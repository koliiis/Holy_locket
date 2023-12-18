using Holy_locket.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.DAL.Models
{
    public class Rating : TEntity
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        [Required]
        public int Rate { get; set; }
        [NotMapped]
        public Doctor Doctor { get; set; }
        [NotMapped]
        public Patient Patient { get; set; }
        public override bool Inactive { get; set; }
    }
}
