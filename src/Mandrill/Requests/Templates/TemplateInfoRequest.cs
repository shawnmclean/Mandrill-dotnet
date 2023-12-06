using System.Text.Json.Serialization;

namespace Mandrill.Requests.Templates
{
  public class TemplateInfoRequest : RequestBase
  {
    public TemplateInfoRequest(string name)
    {
      Name = name;
    }

    [JsonPropertyName("name")]
    public string Name { get; set; }
  }
}