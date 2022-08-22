using System.Text.Json.Serialization;

namespace Mandrill.Requests.Messages
{
  public class ListScheduledMessagesRequest : RequestBase
  {
    [JsonPropertyName("to")]
    public string ToEmail { get; set; }
  }
}