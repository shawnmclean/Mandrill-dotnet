using System;

namespace Mandrill.Utilities
{
  public class MandrillRequestException : MandrillException
  {
    public MandrillRequestException(string message, Exception ex)
        : base(message, ex)
    {
    }
  }
}
