using System;
using Mandrill.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mandrill
{
    public class SmtpEvent
    {
        public int ts { get; set; }
        public DateTime TimeStamp
        {
            get
            {
                return WebHookEvent.FromUnixTime(ts);
            }
        }
        public int size { get; set; }
        public string destination_ip { get; set; }
        public string source_ip { get; set; }
        public string diag { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SearchResultState type { get; set; }
    }
}