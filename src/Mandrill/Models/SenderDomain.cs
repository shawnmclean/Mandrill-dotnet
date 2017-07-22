// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SenderDomain.cs" company="">
//   
// </copyright>
// <summary>
//   The sender domain.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace Mandrill.Models
{
  /// <summary>
  ///   The sender domain.
  /// </summary>
  public class SenderDomain
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the created_at.
    /// </summary>
    public string CreatedAt { get; set; }

    /// <summary>
    ///   Gets or sets the dkim.
    /// </summary>
    public Dkim Dkim { get; set; }

    /// <summary>
    ///   Gets or sets the domain.
    /// </summary>
    public string Domain { get; set; }

    /// <summary>
    ///   Gets or sets the last_tested_at.
    /// </summary>
    public string LastTestedAt { get; set; }

    /// <summary>
    ///   Gets or sets the spf.
    /// </summary>
    public Spf Spf { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether valid_signing.
    /// </summary>
    public bool ValidSigning { get; set; }

    /// <summary>
    ///   Gets or sets the verified_at.
    /// </summary>
    public string VerifiedAt { get; set; }

    #endregion
  }
}