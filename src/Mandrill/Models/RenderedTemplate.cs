// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderedTemplate.cs" company="">
//   
// </copyright>
// <summary>
//   The rendered template.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

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
    [JsonProperty("html")]
    public string Html { get; set; }

    #endregion
  }
}