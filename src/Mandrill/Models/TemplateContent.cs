// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemplateContent.cs" company="">
//   
// </copyright>
// <summary>
//   The template content.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace Mandrill.Models
{
  /// <summary>
  ///   The template content.
  /// </summary>
  public class TemplateContent
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the content.
    /// </summary>
    [JsonProperty("content")]
    public string content { get; set; }

    /// <summary>
    ///   Gets or sets the name.
    /// </summary>
    [JsonProperty("name")]
    public string name { get; set; }

    #endregion
  }
}