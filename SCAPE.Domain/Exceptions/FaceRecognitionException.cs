using System;
using System.Collections.Generic;
using System.Text;

namespace SCAPE.Domain.Exceptions
{
    public class FaceRecognitionException: Exception
    {
        public FaceRecognitionException() { }

        public FaceRecognitionException(string message) : base(message) { }
    }
}
