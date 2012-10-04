using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mandrill
{
    public enum SearchResultState
    {
        Sent,
        Bounced,
        Rejected
    }

    public class SearchResult
    {
        public int ts { get; set; }
        public string sender { get; set; }
        public string subject { get; set; }
        public string email { get; set; }
        public string[] tags { get; set; }
        public int  opens { get; set; }
        public int clicks { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SearchResultState state { get; set; }
    }
}
