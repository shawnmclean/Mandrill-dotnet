using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mandrill.Models.Requests
{
  public class SenderCheckDomainRequest : RequestBase
  {
    public SenderCheckDomainRequest(string domain)
    {
      Domain = domain;
    }

    [JsonProperty("domain")]
    public string Domain { get; set; }
  }
}
