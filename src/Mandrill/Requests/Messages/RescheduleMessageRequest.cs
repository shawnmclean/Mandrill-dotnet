using System;
using System.Text.Json.Serialization;

namespace Mandrill.Requests.Messages
{
  public class RescheduleMessageRequest : RequestBase
  {
    public RescheduleMessageRequest(string id, DateTime sendAt)
    {
      Id = id;
      SendAt = sendAt;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("send_at")]
    public DateTime SendAt { get; set; }
  }
}