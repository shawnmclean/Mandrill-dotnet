using System.Text.Json.Serialization;

namespace Mandrill.Requests.Templates
{
  public class DeleteTemplateRequest : RequestBase
  {
    public DeleteTemplateRequest(string name)
    {
      Name = name;
    }

    [JsonPropertyName("name")]
    public string Name { get; set; }
  }
}