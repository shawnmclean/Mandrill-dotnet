using System.Text.Json.Serialization;

namespace Mandrill.Requests.SubAccounts
{
  public class PauseSubAccountRequest : RequestBase
  {
    public PauseSubAccountRequest(string id)
    {
      Id = id;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }
  }
}