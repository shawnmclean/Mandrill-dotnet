using Newtonsoft.Json;

namespace Mandrill.Requests.Templates
{
  public class TemplateInfoRequest : RequestBase
  {
    public TemplateInfoRequest(string name)
    {
      Name = name;
    }

    [JsonProperty("name")]
    public string Name { get; set; }
  }
}