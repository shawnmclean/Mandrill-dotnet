using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mandrill.Models.Requests
{
  public class ListScheduledMessagesRequest : RequestBase
  {
    [JsonProperty("to")]
    public string ToEmail { get; set; }
  }
}
