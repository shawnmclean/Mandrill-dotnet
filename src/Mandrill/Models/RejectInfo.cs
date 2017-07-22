// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RejectInfo.cs" company="">
//   
// </copyright>
// <summary>
//   The reject info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Newtonsoft.Json;

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
    public string CreatedAt { get; set; }

    /// <summary>
    ///   Gets or sets the email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether expired.
    /// </summary>
    public bool Expired { get; set; }

    /// <summary>
    ///   Gets or sets the expires at.
    /// </summary>
    public string ExpiresAt { get; set; }

    /// <summary>
    ///   Gets or sets the expires at.
    /// </summary>
    public DateTime LastEventAt { get; set; }

    /// <summary>
    ///   Gets or sets the reason.
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    ///   Gets or sets the reason.
    /// </summary>
    public string Detail { get; set; }

    /// <summary>
    ///   Gets or sets the reason.
    /// </summary>
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
    public bool Added { get; set; }

    /// <summary>
    ///   Gets or sets the email.
    /// </summary>
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
    public bool Deleted { get; set; }

    /// <summary>
    ///   Gets or sets the email.
    /// </summary>
    public string Email { get; set; }

    #endregion
  }
}