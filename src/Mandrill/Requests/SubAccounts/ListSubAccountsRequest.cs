using Newtonsoft.Json;

namespace Mandrill.Requests.SubAccounts
{
  public class ListSubAccountsRequest : RequestBase
  {
    [JsonProperty("q")]
    public string Q { get; set; }
  }
}