using System.Text.Json.Serialization;

namespace Mandrill.Requests.SubAccounts
{
  public class DeleteSubAccountRequest : RequestBase
  {
    public DeleteSubAccountRequest(string id)
    {
      Id = id;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }
  }
}