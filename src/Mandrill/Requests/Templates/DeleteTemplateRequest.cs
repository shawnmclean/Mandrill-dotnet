using Newtonsoft.Json;

namespace Mandrill.Requests.Templates
{
  public class DeleteTemplateRequest : RequestBase
  {
    public DeleteTemplateRequest(string name)
    {
      Name = name;
    }

    [JsonProperty("name")]
    public string Name { get; set; }
  }
}