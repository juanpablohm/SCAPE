using System;
using System.Collections.Generic;
using System.Text;

namespace SCAPE.Domain.Exceptions
{
    public class EmployeeException : Exception
    {
        public EmployeeException() { }

        public EmployeeException(string message) : base(message) { }
    }
}
