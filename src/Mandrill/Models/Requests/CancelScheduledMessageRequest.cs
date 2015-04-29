﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mandrill.Models.Requests
{
  public class CancelScheduledMessageRequest : RequestBase
  {
    [JsonProperty("id")]
    public string Id { get; set; }
  }
}
