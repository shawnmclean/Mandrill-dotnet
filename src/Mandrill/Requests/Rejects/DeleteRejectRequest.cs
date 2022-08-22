using System.Text.Json.Serialization;

namespace Mandrill.Requests.Rejects
{
  /// <summary>
  ///   Class DeleteRejectRequest.
  /// </summary>
  public class DeleteRejectRequest : RequestBase
  {
    public DeleteRejectRequest(string email)
    {
      Email = email;
    }

    /// <summary>
    ///   Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    ///   Gets or sets the subaccount.
    /// </summary>
    /// <value>The subaccount.</value>
    [JsonPropertyName("subaccount")]
    public string SubAccount { get; set; }
  }
}