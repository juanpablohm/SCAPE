using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAPE.API.ActionsModels
{
    public class UserModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
