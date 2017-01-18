using System;

using Mandrill.Models;

namespace Mandrill.Utilities
{
  public class MandrillDeserializeResponseException : MandrillException
  {
    public MandrillDeserializeResponseException(string message)
        : base(message)
    {
    }

    public MandrillDeserializeResponseException(ErrorResponse error, string message)
        : base(error, message)
    {
    }

    public MandrillDeserializeResponseException(string message, Exception innerException)
: base(message, innerException)
    {
    }

    public string Content { get; set; }
  }
}