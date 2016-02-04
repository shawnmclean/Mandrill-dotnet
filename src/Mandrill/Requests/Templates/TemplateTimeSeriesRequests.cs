using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandrill.Requests.Templates
{
  /// <summary>
  /// Class TemplateTimeSeriesRequest.
  /// </summary>
  public class TemplateTimeSeriesRequest : RequestBase
  {
    public TemplateTimeSeriesRequest(string name)
    {
      Name = name;
    }

    /// <summary>
    /// Gets or sets the template name.
    /// </summary>
    /// <value>The template name.</value>
    [JsonProperty("name")]
    public string Name { get; set; }
  }
}
