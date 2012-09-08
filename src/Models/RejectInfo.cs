using Newtonsoft.Json;

namespace Mandrill
{
    public class RejectInfo
    {
        
    }

    public class RejectDeleteResult
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}