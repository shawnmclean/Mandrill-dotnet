using System.Collections.Generic;
using Mandrill.Models;
using System.Text.Json.Serialization;

/// <summary>
/// The Requests namespace.
/// </summary>

namespace Mandrill.Requests.Templates
{
  /// <summary>
  ///   Class RenderTemplateRequest.
  /// </summary>
  public class RenderTemplateRequest : RequestBase
  {
    public RenderTemplateRequest(string templateName)
    {
      TemplateName = templateName;
    }

    /// <summary>
    ///   Gets or sets the template_name.
    /// </summary>
    /// <value>The template_name.</value>
    [JsonPropertyName("template_name")]
    public string TemplateName { get; set; }

    /// <summary>
    ///   Gets or sets the template_content.
    /// </summary>
    /// <value>The template_content.</value>
    [JsonPropertyName("template_content")]
    public IEnumerable<TemplateContent> TemplateContent { get; set; }

    /// <summary>
    ///   Gets or sets the merge_vars.
    /// </summary>
    /// <value>The merge_vars.</value>
    [JsonPropertyName("merge_vars")]
    public IEnumerable<MergeVar> MergeVars { get; set; }
  }
}