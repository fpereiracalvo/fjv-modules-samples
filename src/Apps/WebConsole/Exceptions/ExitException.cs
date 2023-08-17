using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompt.Web.Exceptions
{
    public class ExitException : Exception
    {
        public ExitException()
        {
        }

        public ExitException(string message) : base(message)
        {
        }

        public ExitException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}