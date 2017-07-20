using System;

using Mandrill.Models;

namespace Mandrill.Utilities
{
  public class MandrillSerializationException : MandrillException
  {
    public MandrillSerializationException(string message)
        : base(message)
    {
    }

    public MandrillSerializationException(ErrorResponse error, string message)
        : base(error, message)
    {
    }

    public MandrillSerializationException(string message, Exception innerException)
: base(message, innerException)
    {
    }

    public string Content { get; set; }
  }
}