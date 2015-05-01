using Newtonsoft.Json;

namespace Mandrill.Models.Requests
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