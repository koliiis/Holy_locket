﻿using Holy_locket.DAL.Abstracts;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.DAL.Models
{
    public class Appointment : TEntity
    {
        public override int Id { get; set; }
        public override bool Inactive { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        [NotMapped]
        public Hospital Hospital { get; set; }
        public int HospitalId { get; set; }
        [NotMapped]
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        [NotMapped]
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}
