using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mandrill.Models.Requests
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
