using System;
using System.Collections.Generic;
using System.Text;

namespace SCAPE.Application.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string DocumentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string FaceListId { get; set; }
        public DateTime? DateBirth { get; set; }
    }
}
