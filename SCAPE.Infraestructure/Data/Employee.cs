using System;
using System.Collections.Generic;

namespace SCAPE.Infraestructure.Data
{
    public partial class Employee
    {
        public Employee()
        {
            Attendance = new HashSet<Attendance>();
            EmployeeWorkPlace = new HashSet<EmployeeWorkPlace>();
            Image = new HashSet<Image>();
        }

        public int Id { get; set; }
        public string DocumentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public DateTime DateBirth { get; set; }

        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<EmployeeWorkPlace> EmployeeWorkPlace { get; set; }
        public virtual ICollection<Image> Image { get; set; }
    }
}
