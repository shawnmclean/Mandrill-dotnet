using Newtonsoft.Json;

namespace Mandrill.Requests.Messages
{
  public class CancelScheduledMessageRequest : RequestBase
  {
    public CancelScheduledMessageRequest(string id)
    {
      Id = id;
    }

    [JsonProperty("id")]
    public string Id { get; set; }
  }
}