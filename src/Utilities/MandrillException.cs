using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandrill
{
    /// <summary>
    /// General Exception that is thrown by the Mandrill Api
    /// </summary>
    public class MandrillException : Exception
    {
        public ErrorResponse Error { get; private set; }

        public MandrillException() { }

        public MandrillException(string message)
            : base(message)
        {
        }

        public MandrillException(ErrorResponse error, string message)
            : base(message)
        {
            this.Error = error;
        }

        public MandrillException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
