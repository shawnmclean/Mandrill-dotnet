using System;

namespace Mandrill.Utilities
{
  public class MandrillSerializeRequestException : MandrillException
  {
    public MandrillSerializeRequestException(string message, Exception ex)
        : base(message, ex)
    {
    }
  }
}
