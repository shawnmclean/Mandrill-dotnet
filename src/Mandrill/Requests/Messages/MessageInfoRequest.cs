using System.Text.Json.Serialization;

namespace Mandrill.Requests.Messages
{
  public class MessageInfoRequest : RequestBase
  {
    public MessageInfoRequest(string id)
    {
      Id = id;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }
  }
}