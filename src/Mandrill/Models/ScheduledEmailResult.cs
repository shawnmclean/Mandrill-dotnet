using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mandrill
{
    public class ScheduledEmailResult
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("send_at")]
        public DateTime SendAt { get; set; }

        [JsonProperty("from_email")]
        public string FromEmail { get; set; }

        [JsonProperty("to")]
        public string ToEmail { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

    }
}
