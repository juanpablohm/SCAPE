using System;
using System.Collections.Generic;

namespace SCAPE.Domain.Entities
{
    public class Image
    {
        public string Url { get; set; }
        public int IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
