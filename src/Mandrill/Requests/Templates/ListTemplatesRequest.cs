using System.Text.Json.Serialization;

namespace Mandrill.Requests.Templates
{
  public class ListTemplatesRequest : RequestBase
  {
    [JsonPropertyName("label")]
    public string Label { get; set; }
  }
}