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
        public string LatitudePosition { get; set; }
        public string LongitudePosition { get; set; }
        public string FaceListId { get; set; }

        public virtual ICollection<EmployeeWorkPlace> EmployeeWorkPlace { get; set; }
    }
}
