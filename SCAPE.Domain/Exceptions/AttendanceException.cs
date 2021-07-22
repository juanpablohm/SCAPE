using System;
using System.Collections.Generic;
using System.Text;

namespace SCAPE.Domain.Exceptions
{
    public class AttendanceException : Exception
    {
        public AttendanceException() { }

        public AttendanceException(string message) : base(message) { }
    }
}
