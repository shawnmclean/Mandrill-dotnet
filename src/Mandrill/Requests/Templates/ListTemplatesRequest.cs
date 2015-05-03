using Newtonsoft.Json;

namespace Mandrill.Requests.Templates
{
  public class ListTemplatesRequest : RequestBase
  {
    [JsonProperty("label")]
    public string Label { get; set; }
  }
}