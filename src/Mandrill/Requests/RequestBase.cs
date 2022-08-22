using System.Text.Json.Serialization;

namespace Mandrill.Requests
{
  /// <summary>
  ///   Base Payload class for all request going to Mandrill Servers
  /// </summary>
  public class RequestBase
  {
    /// <summary>
    ///   The API Key property.
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; set; }
  }
}