using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Mandrill.Models.Payloads
{
  public abstract class PayloadBase
  {
    [JsonProperty("key", Order = 0)]
    public string Key { get; set; }
  }
}
