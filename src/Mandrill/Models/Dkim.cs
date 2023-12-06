// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dkim.cs" company="">
//   
// </copyright>
// <summary>
//   The dkim.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  /// <summary>
  ///   The dkim.
  /// </summary>
  public class Dkim
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the error.
    /// </summary>
    [JsonPropertyName("error")]
    public string Error { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether valid.
    /// </summary>
    [JsonPropertyName("valid")]
    public bool Valid { get; set; }

    /// <summary>
    ///   Gets or sets the valid_after.
    /// </summary>
    [JsonPropertyName("valid_after")]
    public string ValidAfter { get; set; }

    #endregion
  }
}