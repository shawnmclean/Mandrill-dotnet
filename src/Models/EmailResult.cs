using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Mandrill
{
    public enum EmailResultStatus
    {
        Sent, 
        Queued,
        Rejected,
        Invalid
    }

    public class EmailResult
    {
        public string Email { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public EmailResultStatus Status { get; set; }
    }
}