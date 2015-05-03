using Newtonsoft.Json;

namespace Mandrill.Requests.SubAccounts
{
  public class DeleteSubAccountRequest : RequestBase
  {
    public DeleteSubAccountRequest(string id)
    {
      Id = id;
    }

    [JsonProperty("id")]
    public string Id { get; set; }
  }
}