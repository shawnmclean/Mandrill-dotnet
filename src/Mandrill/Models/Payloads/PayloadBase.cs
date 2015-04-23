using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Mandrill.Models.Payloads
{
  /// <summary>
  /// Base Payload class for all request going to Mandrill Servers
  /// </summary>
  public abstract class PayloadBase
  {
    /// <summary>
    /// The API Key property. Order at 0 because Mandrill does not seem to accept the Key anywhere else but at the start of the json document.
    /// </summary>
    [JsonProperty("key", Order = 0)]
    public string Key { get; set; }
  }
}
