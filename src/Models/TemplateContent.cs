using Newtonsoft.Json;

namespace Mandrill
{
    public class TemplateContent
    {

        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}