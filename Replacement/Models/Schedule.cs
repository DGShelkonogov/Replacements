﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacement.Models
{
    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
    }

    public class Schedule
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set;}
        public virtual ICollection<Lession> Lessions { get; set; } = new List<Lession>();
    }
}
