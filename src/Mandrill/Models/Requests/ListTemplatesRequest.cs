using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mandrill.Models.Requests
{
  public class ListTemplatesRequest : RequestBase
  {
    [JsonProperty("label")]
    public string Label { get; set; }
  }
}
