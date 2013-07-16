using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Mandrill
{
    public enum EmailResultStatus
    {
        Sent, 
        Queued,
        Rejected,
        Invalid,
        Scheduled
    }

    public class EmailResult
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        public string Email { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public EmailResultStatus Status { get; set; }
    }
}