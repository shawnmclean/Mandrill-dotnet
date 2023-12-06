using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  public class MergeVars
  {
    [JsonPropertyName("rcpt")]
    public string Rcpt { get; set; }

    [JsonPropertyName("vars")]
    public IEnumerable<TemplateContent> Vars { get; set; }
  }
}
