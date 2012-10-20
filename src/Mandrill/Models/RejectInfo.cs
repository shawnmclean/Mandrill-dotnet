using Newtonsoft.Json;

namespace Mandrill
{
    public class RejectInfo
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; }

        [JsonProperty("expired")]
        public bool Expired { get; set; }
        
        //TODO: Add property: Sender: "Sender":{"...": "..."}
    }

    public class RejectDeleteResult
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}
