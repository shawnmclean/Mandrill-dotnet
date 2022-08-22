using System.Text.Json.Serialization;

namespace Mandrill.Requests.SubAccounts
{
  public class ResumeSubAccountRequest : RequestBase
  {
    public ResumeSubAccountRequest(string id)
    {
      Id = id;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }
  }
}