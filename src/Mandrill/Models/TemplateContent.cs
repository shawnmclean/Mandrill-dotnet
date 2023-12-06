// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemplateContent.cs" company="">
//   
// </copyright>
// <summary>
//   The template content.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

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
    [JsonPropertyName("content")]
    public string Content { get; set; }

    /// <summary>
    ///   Gets or sets the name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    #endregion
  }
}