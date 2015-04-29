using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mandrill.Models.Requests
{
  public class RescheduleMessageRequest : RequestBase
  {
    public RescheduleMessageRequest(string id, DateTime sendAt)
    {
      Id = id;
      SendAt = sendAt;
    }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("send_at")]
    public DateTime SendAt { get; set; }
  }
}
