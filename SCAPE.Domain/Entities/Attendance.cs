using System;
using System.Collections.Generic;

namespace SCAPE.Domain.Entities
{
    public  class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
