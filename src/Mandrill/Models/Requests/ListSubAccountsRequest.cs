using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mandrill.Models.Requests
{
  public class ListSubAccountsRequest : RequestBase
  {
    [JsonProperty("q")]
    public string Q { get; set; }
  }
}
