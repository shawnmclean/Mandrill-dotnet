using System.Text.Json.Serialization;

namespace Mandrill.Requests.SubAccounts
{
  /// <summary>
  ///   Class AddSubAccountRequest.
  /// </summary>
  public class AddSubAccountRequest : RequestBase
  {
    public AddSubAccountRequest(string id)
    {
      Id = id;
    }

    /// <summary>
    ///   Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    ///   Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///   Gets or sets the notes.
    /// </summary>
    /// <value>The notes.</value>
    [JsonPropertyName("notes")]
    public string Notes { get; set; }

    /// <summary>
    ///   Gets or sets the custom_quota.
    /// </summary>
    /// <value>The custom_quota.</value>
    [JsonPropertyName("custom_quota")]
    public int? CustomQuota { get; set; }
  }
}