using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mandrill.Models.Payloads
{
  public class GetContentPayload : PayloadBase
  {
    [JsonProperty("id", Order = 1)]
    public string Id { get; set; }
  }
}
