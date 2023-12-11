﻿using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.DTO
{
    public class DoctorDTO
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }   
        public int Experience { get; set; }
        public int SpecialityId { get; set; }
        public string SpecialityName { get; set; }
        public double Rating { get; set; }
    }
}
