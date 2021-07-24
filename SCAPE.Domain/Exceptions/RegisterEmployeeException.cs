using System;
using System.Collections.Generic;
using System.Text;

namespace SCAPE.Domain.Exceptions
{
    public class RegisterEmployeeException : Exception
    {
        public RegisterEmployeeException() { }

        public RegisterEmployeeException(string message) : base(message) { }

        public static implicit operator RegisterEmployeeException(FaceRecognitionException v)
        {
            throw new NotImplementedException();
        }
    }
}
