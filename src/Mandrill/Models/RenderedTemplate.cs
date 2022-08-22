// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderedTemplate.cs" company="">
//   
// </copyright>
// <summary>
//   The rendered template.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  /// <summary>
  ///   The rendered template.
  /// </summary>
  public class RenderedTemplate
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the html.
    /// </summary>
    [JsonPropertyName("html")]
    public string Html { get; set; }

    #endregion
  }
}