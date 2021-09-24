using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAPE.Application.DTOs
{
    public class TokenModelDTO
    {
        public TokenModelDTO(string access_token, string token_type, double expires_in, string scope)
        {
            this.access_token = access_token;
            this.token_type = token_type;
            this.expires_in = expires_in;
            this.scope = scope;
        }

        public string access_token { get; set; }
        public string token_type { get; set; }
        public double expires_in { get; set; }
        public string scope { get; set; }
    }
}
