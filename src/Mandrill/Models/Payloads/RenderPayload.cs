using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mandrill.Models.Payloads
{
  internal class RenderPayload : PayloadBase
  {
    [JsonProperty("template_name", Order = 1)]
    public string TemplateName { get; set; }
    [JsonProperty("template_content", Order = 1)]
    public IEnumerable<TemplateContent> TemplateContents { get; set; }
    [JsonProperty("merge_vars", Order = 1)]
    public IEnumerable<MergeVar> MergeVars { get; set; }
  }
}
