// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SenderDomain.cs" company="">
//   
// </copyright>
// <summary>
//   The sender domain.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

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
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    /// <summary>
    ///   Gets or sets the dkim.
    /// </summary>
    [JsonPropertyName("dkim")]
    public Dkim Dkim { get; set; }

    /// <summary>
    ///   Gets or sets the domain.
    /// </summary>
    [JsonPropertyName("domain")]
    public string Domain { get; set; }

    /// <summary>
    ///   Gets or sets the last_tested_at.
    /// </summary>
    [JsonPropertyName("last_tested_at")]
    public string LastTestedAt { get; set; }

    /// <summary>
    ///   Gets or sets the spf.
    /// </summary>
    [JsonPropertyName("spf")]
    public Spf Spf { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether valid_signing.
    /// </summary>
    [JsonPropertyName("valid_signing")]
    public bool ValidSigning { get; set; }

    /// <summary>
    ///   Gets or sets the verified_at.
    /// </summary>
    [JsonPropertyName("verified_at")]
    public string VerifiedAt { get; set; }

    #endregion
  }
}