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
    public class Hospital : TEntity
    {
        public override int Id { get; set; }
        public override bool Inactive { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(4)]
        public string Title { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(7)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(7)]
        public string Adress { get; set; }
        [NotMapped]
        public ICollection<Appointment> AppointmentList { get; set; }
    }

}
