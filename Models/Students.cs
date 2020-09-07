using System;
using System.Collections.Generic;

namespace SchoolLife.Models
{
    public partial class Students
    {
        public int Class { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }

        public virtual Attendance RollNoNavigation { get; set; }
    }
}
