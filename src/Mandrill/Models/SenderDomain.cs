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
    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }

    /// <summary>
    ///   Gets or sets the dkim.
    /// </summary>
    [JsonProperty("dkim")]
    public Dkim Dkim { get; set; }

    /// <summary>
    ///   Gets or sets the domain.
    /// </summary>
    [JsonProperty("domain")]
    public string Domain { get; set; }

    /// <summary>
    ///   Gets or sets the last_tested_at.
    /// </summary>
    [JsonProperty("last_tested_at")]
    public string LastTestedAt { get; set; }

    /// <summary>
    ///   Gets or sets the spf.
    /// </summary>
    [JsonProperty("spf")]
    public Spf Spf { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether valid_signing.
    /// </summary>
    [JsonProperty("valid_signing")]
    public bool ValidSigning { get; set; }

    /// <summary>
    ///   Gets or sets the verified_at.
    /// </summary>
    [JsonProperty("verified_at")]
    public string VerifiedAt { get; set; }

    #endregion
  }
}