using System;

using Mandrill.Models;

namespace Mandrill.Utilities
{
  public class MandrillResponseException : MandrillException
  {
    public MandrillResponseException(string message)
        : base(message)
    {
    }

    public MandrillResponseException(ErrorResponse error, string message)
        : base(error, message)
    {
    }

    public MandrillResponseException(string message, Exception innerException)
: base(message, innerException)
    {
    }
  }
}