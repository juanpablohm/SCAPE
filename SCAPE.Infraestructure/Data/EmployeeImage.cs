using System;
using System.Collections.Generic;

namespace SCAPE.Infraestructure.Data
{
    public partial class EmployeeImage
    {
        public int Id { get; set; }
        public byte[] Image1 { get; set; }
        public string PersistenceFaceId { get; set; }
        public int IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
