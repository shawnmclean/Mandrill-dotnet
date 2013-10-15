using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mandrill
{
    public enum SearchResultState
    {
        Sent,
        Bounced,
        Rejected,
        [EnumMember(Value = "soft-bounced")]
        SoftBounced,
        Spam,
        Unsub,
        Deferred
    }

    public class SearchResult
    {
        public int ts { get; set; }
        public string _id { get; set; }
        public string sender { get; set; }
        public string subject { get; set; }
        public string email { get; set; }
        public string[] tags { get; set; }
        public int opens { get; set; }
        public int clicks { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SearchResultState state { get; set; }

        public Dictionary<string, string> metadata { get; set; }

        public string diag { get; set; }
        public string bounce_description { get; set; }
        public IEnumerable<SmtpEvent> smtp_events { get; set; }
    }
}
