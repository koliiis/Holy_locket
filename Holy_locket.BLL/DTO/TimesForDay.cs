﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.DAL.Models
{
    public class TimesForDayDTO
    {
        public int Id { get; set; }
        public bool Inactive { get; set; }
        public ICollection<TimeSlot> TimeSlotList { get; set; }
    }
}
