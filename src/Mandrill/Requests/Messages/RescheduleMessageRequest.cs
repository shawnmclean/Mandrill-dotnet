using System;
using Newtonsoft.Json;

namespace Mandrill.Requests.Messages
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