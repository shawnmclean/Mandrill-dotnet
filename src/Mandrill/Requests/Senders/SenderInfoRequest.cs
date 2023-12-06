using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Mandrill.Requests.Senders
{
  public class SenderInfoRequest : RequestBase
  {
    public SenderInfoRequest(string address)
    {
       Address = address;
    }

    [JsonPropertyName("address")]
    public string Address { get; set; }
  }
}
