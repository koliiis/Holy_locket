using Holy_locket.DAL.Abstracts;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.DAL.Models
{
    public class Doctor : TEntity
    {
        public override int Id { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(4)]
        public override bool Inactive { get; set; }
        public string FirstName { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(2)]
        public string SecondName { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public int Experience { get; set; }
        public string? Photo { get; set; }
        public int SpecialityId { get; set; }
        [NotMapped]
        public Speciality Speciality { get; set; }
        [NotMapped]
        public ICollection<Appointment> AppointmentList { get; set; }
        [NotMapped]
        public ICollection<Rating> RatingList { get; set; }
    }
}
