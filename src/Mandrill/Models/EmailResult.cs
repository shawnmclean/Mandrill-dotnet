// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailResult.cs" company="">
//   
// </copyright>
// <summary>
//   The email result status.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  /// <summary>
  ///   The email result status.
  /// </summary>
  public enum EmailResultStatus
  {
    /// <summary>
    ///   The sent.
    /// </summary>
    Sent,

    /// <summary>
    ///   The queued.
    /// </summary>
    Queued,

    /// <summary>
    ///   The rejected.
    /// </summary>
    Rejected,

    /// <summary>
    ///   The invalid.
    /// </summary>
    Invalid,

    /// <summary>
    ///   The scheduled.
    /// </summary>
    Scheduled
  }

  /// <summary>
  ///   The email result.
  /// </summary>
  public class EmailResult
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the email.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    ///   Gets or sets the id.
    /// </summary>
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    /// <summary>
    ///   Reason for reject
    /// </summary>
    [JsonPropertyName("reject_reason")]
    public string RejectReason { get; set; }

    /// <summary>
    ///   Gets or sets the status.
    /// </summary>
    [JsonPropertyName("status")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public EmailResultStatus Status { get; set; }

    #endregion
  }
}