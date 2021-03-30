using System;
using System.Collections.Generic;

namespace SCAPE.Domain.Entities
{
    public  class EmployeeWorkPlace
    {
        public int IdEmployee { get; set; }
        public int IdWorkPlace { get; set; }
        public DateTime StartJobDate { get; set; }
        public DateTime EndJobDate { get; set; }
        public string Schedule { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual WorkPlace IdWorkPlaceNavigation { get; set; }
    }
}
