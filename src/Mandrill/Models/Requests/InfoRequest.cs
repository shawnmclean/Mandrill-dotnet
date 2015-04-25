using Newtonsoft.Json;

namespace Mandrill.Models.Requests
{
  public class InfoRequest : RequestBase
  {
    [JsonProperty("id")]
    public string Id { get; set; }
  }
}
