﻿using Holy_locket.DAL.Abstracts;
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
    public class Doctor : User
    {
        public string Description { get; set; }
        public string Gender { get; set; }
        public int Experience { get; set; }
        public double Rating { get; set; }
        public int SpecialityId { get; set; }
        [NotMapped]
        public Speciality Speciality { get; set; }
        [NotMapped]
        public ICollection<Appointment> AppointmentList { get; set; }
        [NotMapped]
        public ICollection<Rating> RatingList { get; set; }
        [NotMapped]
        public ICollection<TimesForDay> TimesForDayList { get; set; }
        public override int Role { get; set; } = 2;
    }
}
