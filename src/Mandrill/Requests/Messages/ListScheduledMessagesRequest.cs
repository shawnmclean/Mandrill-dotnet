using Newtonsoft.Json;

namespace Mandrill.Requests.Messages
{
  public class ListScheduledMessagesRequest : RequestBase
  {
    [JsonProperty("to")]
    public string ToEmail { get; set; }
  }
}