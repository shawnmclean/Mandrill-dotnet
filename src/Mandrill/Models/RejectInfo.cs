// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RejectInfo.cs" company="">
//   
// </copyright>
// <summary>
//   The reject info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  /// <summary>
  ///   The reject info.
  /// </summary>
  public class RejectInfo
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the created at.
    /// </summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    /// <summary>
    ///   Gets or sets the email.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether expired.
    /// </summary>
    [JsonPropertyName("expired")]
    public bool Expired { get; set; }

    /// <summary>
    ///   Gets or sets the expires at.
    /// </summary>
    [JsonPropertyName("expires_at")]
    public string ExpiresAt { get; set; }

    /// <summary>
    ///   Gets or sets the expires at.
    /// </summary>
    [JsonPropertyName("last_event_at")]
    public DateTime LastEventAt { get; set; }

    /// <summary>
    ///   Gets or sets the reason.
    /// </summary>
    [JsonPropertyName("reason")]
    public string Reason { get; set; }

    /// <summary>
    ///   Gets or sets the detail.
    /// </summary>
    [JsonPropertyName("detail")]
    public string Detail { get; set; }

    /// <summary>
    ///   Gets or sets the sender.
    /// </summary>
    [JsonPropertyName("sender")]
    public Sender Sender { get; set; }

    #endregion
  }

  /// <summary>
  ///   The reject add result.
  /// </summary>
  public class RejectAddResult
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets a value indicating whether added.
    /// </summary>
    [JsonPropertyName("added")]
    public bool Added { get; set; }

    /// <summary>
    ///   Gets or sets the email.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    #endregion
  }

  /// <summary>
  ///   The reject delete result.
  /// </summary>
  public class RejectDeleteResult
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets a value indicating whether deleted.
    /// </summary>
    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }

    /// <summary>
    ///   Gets or sets the email.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    #endregion
  }
}