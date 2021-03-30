using System;
using System.Collections.Generic;

namespace SCAPE.Domain.Entities
{
    public  class WorkPlace
    {
        public WorkPlace()
        {
            EmployeeWorkPlace = new HashSet<EmployeeWorkPlace>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal LatitudePosition { get; set; }
        public decimal LongitudePosition { get; set; }

        public virtual ICollection<EmployeeWorkPlace> EmployeeWorkPlace { get; set; }
    }
}
