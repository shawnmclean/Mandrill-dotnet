// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduledEmailResult.cs" company="">
//   
// </copyright>
// <summary>
//   The scheduled email result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  /// <summary>
  ///   The scheduled email result.
  /// </summary>
  public class ScheduledEmailResult
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the created at.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///   Gets or sets the from email.
    /// </summary>
    [JsonPropertyName("from_email")]
    public string FromEmail { get; set; }

    /// <summary>
    ///   Gets or sets the id.
    /// </summary>
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    /// <summary>
    ///   Gets or sets the send at.
    /// </summary>
    [JsonPropertyName("send_at")]
    public DateTime SendAt { get; set; }

    /// <summary>
    ///   Gets or sets the subject.
    /// </summary>
    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    /// <summary>
    ///   Gets or sets the to email.
    /// </summary>
    [JsonPropertyName("to")]
    public string ToEmail { get; set; }

    #endregion
  }
}