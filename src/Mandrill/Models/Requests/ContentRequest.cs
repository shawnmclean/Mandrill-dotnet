using Newtonsoft.Json;

namespace Mandrill.Models.Requests
{
  public class ContentRequest : RequestBase
  {
    /// <summary>
    ///  Unique id of the message to get -- passed as the "_id" field in
    ///     webhooks, send calls, or search calls.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
  }
}
