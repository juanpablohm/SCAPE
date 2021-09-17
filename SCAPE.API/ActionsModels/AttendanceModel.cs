using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAPE.API.ActionsModels
{
    public class AttendanceModel
    {
        public string documentEmployee { get; set; }
        public string type { get; set; }
        public DateTime dateTime { get; set; }
    }
}
