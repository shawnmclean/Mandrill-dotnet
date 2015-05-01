using Newtonsoft.Json;

namespace Mandrill.Models.Requests
{
  public class MessageInfoRequest : RequestBase
  {
    [JsonProperty("id")]
    public string Id { get; set; }
  }
}
