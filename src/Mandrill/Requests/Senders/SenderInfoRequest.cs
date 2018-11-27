using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Mandrill.Requests.Senders
{
  public class SenderInfoRequest : RequestBase
  {
    public SenderInfoRequest(string address)
    {
       Address = address;
    }

    [JsonProperty("address")]
    public string Address { get; set; }
  }
}
