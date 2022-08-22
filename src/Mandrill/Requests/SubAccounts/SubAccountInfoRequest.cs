using System.Text.Json.Serialization;

namespace Mandrill.Requests.SubAccounts
{
  public class SubAccountInfoRequest : RequestBase
  {
    public SubAccountInfoRequest(string id)
    {
      Id = id;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }
  }
}