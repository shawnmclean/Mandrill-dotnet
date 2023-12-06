using System.Text.Json.Serialization;

namespace Mandrill.Requests.Messages
{
  public class CancelScheduledMessageRequest : RequestBase
  {
    public CancelScheduledMessageRequest(string id)
    {
      Id = id;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }
  }
}