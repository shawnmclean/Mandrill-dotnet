using System.Text.Json.Serialization;

namespace Mandrill.Requests.SubAccounts
{
  public class ListSubAccountsRequest : RequestBase
  {
    [JsonPropertyName("q")]
    public string Q { get; set; }
  }
}