using Newtonsoft.Json;

namespace Mandrill
{
    public class EmailAddress
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}