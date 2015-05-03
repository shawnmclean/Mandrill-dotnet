using Newtonsoft.Json;

namespace Mandrill.Requests.SubAccounts
{
  public class PauseSubAccountRequest : RequestBase
  {
    public PauseSubAccountRequest(string id)
    {
      Id = id;
    }

    [JsonProperty("id")]
    public string Id { get; set; }
  }
}