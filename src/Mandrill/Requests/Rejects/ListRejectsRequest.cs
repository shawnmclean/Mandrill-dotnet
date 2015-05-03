using Newtonsoft.Json;

namespace Mandrill.Requests.Rejects
{
  /// <summary>
  ///   Class ListRejectsRequest.
  /// </summary>
  public class ListRejectsRequest : RequestBase
  {
    /// <summary>
    ///   Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    [JsonProperty("email")]
    public string Email { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether this <see cref="ListRejectsRequest" /> is include_expired.
    /// </summary>
    /// <value><c>true</c> if include_expired; otherwise, <c>false</c>.</value>
    [JsonProperty("include_expired")]
    public bool IncludeExpired { get; set; }

    /// <summary>
    ///   Gets or sets the subaccount.
    /// </summary>
    /// <value>The subaccount.</value>
    [JsonProperty("subaccount")]
    public string SubAccount { get; set; }
  }
}