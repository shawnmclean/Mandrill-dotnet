// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduledEmailResult.cs" company="">
//   
// </copyright>
// <summary>
//   The scheduled email result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Newtonsoft.Json;

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
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///   Gets or sets the from email.
    /// </summary>
    public string FromEmail { get; set; }

    /// <summary>
    ///   Gets or sets the id.
    /// </summary>
    [JsonProperty("_id")]
    public string Id { get; set; }

    /// <summary>
    ///   Gets or sets the send at.
    /// </summary>
    public DateTime SendAt { get; set; }

    /// <summary>
    ///   Gets or sets the subject.
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    ///   Gets or sets the to email.
    /// </summary>
    [JsonProperty("to")]
    public string ToEmail { get; set; }

    #endregion
  }
}