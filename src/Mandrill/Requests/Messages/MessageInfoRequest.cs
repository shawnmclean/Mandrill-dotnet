using Newtonsoft.Json;

namespace Mandrill.Requests.Messages
{
  public class MessageInfoRequest : RequestBase
  {
    [JsonProperty("id")]
    public string Id { get; set; }
  }
}