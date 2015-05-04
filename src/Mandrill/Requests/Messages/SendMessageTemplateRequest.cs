using System;
using System.Collections.Generic;
using Mandrill.Models;
using Newtonsoft.Json;

namespace Mandrill.Requests.Messages
{
  public class SendMessageTemplateRequest : RequestBase
  {
    public SendMessageTemplateRequest(EmailMessage message, string templateName, IEnumerable<TemplateContent> templateContents)
    {
      Message = message;
      TemplateName = templateName;
      TemplateContents = templateContents;
    }

    [JsonProperty("message")]
    public EmailMessage Message { get; set; }

    [JsonProperty("template_name")]
    public string TemplateName { get; set; }

    [JsonProperty("template_content")]
    public IEnumerable<TemplateContent> TemplateContents { get; set; }

    [JsonProperty("async")]
    public bool Async { get; set; }

    [JsonProperty("send_at")]
    public DateTime? SendAt { get; set; }
  }
}