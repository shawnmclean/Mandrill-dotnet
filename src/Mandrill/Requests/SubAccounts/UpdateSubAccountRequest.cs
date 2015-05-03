using Newtonsoft.Json;

namespace Mandrill.Requests.SubAccounts
{
  /// <summary>
  ///   Class UpdateSubAccountRequest.
  /// </summary>
  public class UpdateSubAccountRequest : RequestBase
  {
    public UpdateSubAccountRequest(string id)
    {
      Id = id;
    }

    /// <summary>
    ///   Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    ///   Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    ///   Gets or sets the notes.
    /// </summary>
    /// <value>The notes.</value>
    [JsonProperty("notes")]
    public string Notes { get; set; }

    /// <summary>
    ///   Gets or sets the custom_quota.
    /// </summary>
    /// <value>The custom_quota.</value>
    [JsonProperty("custom_quota")]
    public int? CustomQuota { get; set; }
  }
}