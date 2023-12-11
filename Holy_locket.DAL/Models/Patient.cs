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
    public class Patient : TEntity
    {
        public override int Id { get; set; }
        public override bool Inactive { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(2)]
        public string SecondName { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(7)]
        public string Phone { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public string?  Photo { get; set; } = "";
        [NotMapped]
        public ICollection<Appointment>? AppointmentList { get; set; }
        [NotMapped]
        public ICollection<Rating> RatingList { get; set; }
    }
}
