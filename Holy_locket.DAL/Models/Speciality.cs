using Holy_locket.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.DAL.Models
{
    public class Speciality : TEntity
    {
        public override int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string Name { get; set; }
        public ICollection<Doctor> DoctorList{ get; set; }
    }
}
