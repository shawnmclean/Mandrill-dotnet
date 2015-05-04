using Newtonsoft.Json;

namespace Mandrill.Requests.Messages
{
  public class MessageInfoRequest : RequestBase
  {
    public MessageInfoRequest(string id)
    {
      Id = id;
    }

    [JsonProperty("id")]
    public string Id { get; set; }
  }
}