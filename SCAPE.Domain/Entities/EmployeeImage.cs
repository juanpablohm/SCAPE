using System;
using System.Collections.Generic;

namespace SCAPE.Domain.Entities
{
    public class EmployeeImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string PersistenceFaceId { get; set; }
        public int IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }


        public EmployeeImage(String persistenceFaceId, int idEmployee, byte[] image)
        {
            PersistenceFaceId = persistenceFaceId;
            IdEmployee = idEmployee;
            Image = image;
        }

    }
}
