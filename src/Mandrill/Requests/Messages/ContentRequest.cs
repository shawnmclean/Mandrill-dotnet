using Newtonsoft.Json;

namespace Mandrill.Requests.Messages
{
  public class ContentRequest : RequestBase
  {
    public ContentRequest(string id)
    {
      Id = id;
    }

    /// <summary>
    ///   Unique id of the message to get -- passed as the "_id" field in
    ///   webhooks, send calls, or search calls.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
  }
}