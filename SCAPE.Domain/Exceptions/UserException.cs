using System;
using System.Collections.Generic;
using System.Text;

namespace SCAPE.Domain.Exceptions
{
    public class UserException : Exception
    {
        public UserException() { }

        public UserException(string message) : base(message) { }
    }
}
