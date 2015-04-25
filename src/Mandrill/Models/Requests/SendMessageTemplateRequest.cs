using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mandrill.Models.Requests
{
  public class SendMessageTemplateRequest : RequestBase
  {
    [JsonProperty("message")]
    public EmailMessage Message { get; set; }
    [JsonProperty("template_name")]
    public string TemplateName { get; set; }
    [JsonProperty("template_content")]
    public IEnumerable<TemplateContent> TemplateContents { get; set; }
    [JsonProperty("async")]
    public bool Async { get; set; }
    [JsonProperty("send_at")]
    public string SendAt { get; set; }
  }
}
