using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mandrill.Models.Payloads
{
  public class SendMessagePayload : PayloadBase
  {
    [JsonProperty("message", Order = 1)]
    public EmailMessage Message { get; set; }
    [JsonProperty("template_name", Order = 1)]
    public string TemplateName { get; set; }
    [JsonProperty("template_content", Order = 1)]
    public IEnumerable<TemplateContent> TemplateContents { get; set; }
    [JsonProperty("async", Order = 1)]
    public bool Async { get; set; }
    [JsonProperty("send_at", Order = 1)]
    public string SendAt { get; set; }
  }
}
