using System;
using System.Collections.Generic;

namespace SchoolLife.Models
{
    public partial class Attendance
    {
        public Attendance()
        {
            Students = new HashSet<Students>();
        }

        public int RollNo { get; set; }
        public string Attendance1 { get; set; }
        public double? Result { get; set; }

        public virtual ICollection<Students> Students { get; set; }
    }
}
