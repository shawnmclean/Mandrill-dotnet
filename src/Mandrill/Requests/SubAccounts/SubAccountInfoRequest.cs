using Newtonsoft.Json;

namespace Mandrill.Requests.SubAccounts
{
  public class SubAccountInfoRequest : RequestBase
  {
    public SubAccountInfoRequest(string id)
    {
      Id = id;
    }

    [JsonProperty("id")]
    public string Id { get; set; }
  }
}