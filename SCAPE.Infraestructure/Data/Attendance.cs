using System;
using System.Collections.Generic;

namespace SCAPE.Infraestructure.Data
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
