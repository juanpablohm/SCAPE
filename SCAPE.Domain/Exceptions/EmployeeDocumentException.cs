using System;
using System.Collections.Generic;
using System.Text;

namespace SCAPE.Domain.Exceptions
{
    public class EmployeeDocumentException: Exception
    {
        public EmployeeDocumentException() { }

        public EmployeeDocumentException(string message) : base(message) { }

    }
}
