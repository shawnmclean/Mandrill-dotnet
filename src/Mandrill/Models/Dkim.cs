// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dkim.cs" company="">
//   
// </copyright>
// <summary>
//   The dkim.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

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
    public string Error { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether valid.
    /// </summary>
    public bool Valid { get; set; }

    /// <summary>
    ///   Gets or sets the valid_after.
    /// </summary>
    public string ValidAfter { get; set; }

    #endregion
  }
}