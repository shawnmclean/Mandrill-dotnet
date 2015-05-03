using System.Collections.Generic;
using Mandrill.Models;
using Newtonsoft.Json;

namespace Mandrill.Requests.Messages
{
  public class RenderRequest : RequestBase
  {
    [JsonProperty("template_name")]
    public string TemplateName { get; set; }

    [JsonProperty("template_content")]
    public IEnumerable<TemplateContent> TemplateContents { get; set; }

    [JsonProperty("merge_vars")]
    public IEnumerable<MergeVar> MergeVars { get; set; }
  }
}