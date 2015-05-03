using Newtonsoft.Json;

namespace Mandrill.Requests.SubAccounts
{
  public class ResumeSubAccountRequest : RequestBase
  {
    public ResumeSubAccountRequest(string id)
    {
      Id = id;
    }

    [JsonProperty("id")]
    public string Id { get; set; }
  }
}