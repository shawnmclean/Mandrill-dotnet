// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemplateInfo.cs" company="">
//   
// </copyright>
// <summary>
//   The template info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  /// <summary>
  ///   The template info.
  /// </summary>
  public class TemplateInfo
  {
    #region Public Properties

    /// <summary>
    ///   The date and time the template was first created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///   The default sender address for the template, if provided.
    /// </summary>
    [JsonPropertyName("from_email")]
    public string FromEmail { get; set; }

    /// <summary>
    ///   The default sender from name for the template, if provided.
    /// </summary>
    [JsonPropertyName("from_name")]
    public string FromName { get; set; }

    /// <summary>
    ///   The list of labels applied to the template.
    /// </summary>
    [JsonPropertyName("labels")]
    public IEnumerable<string> Labels { get; set; }

    /// <summary>
    ///   The default sender address for the template, if provided.
    /// </summary>
    [JsonPropertyName("publish_from_email")]
    public string PublishFromEmail { get; set; }

    /// <summary>
    ///   The default sender from name for the template, if provided.
    /// </summary>
    [JsonPropertyName("publish_from_name")]
    public string PublishFromName { get; set; }

    /// <summary>
    ///   The subject line of the template, if provided.
    /// </summary>
    [JsonPropertyName("publish_subject")]
    public string PublishSubject { get; set; }

    /// <summary>
    ///   The default text part of messages sent with the template, if
    ///   provided.
    /// </summary>
    [JsonPropertyName("publish_text")]
    public string PublishText { get; set; }

    /// <summary>
    ///   The date and time the template was last published, or null if it
    ///   has not been published.
    /// </summary>
    [JsonPropertyName("published")]
    public DateTime Published { get; set; }

    /// <summary>
    ///   The immutable unique code name of the template.
    /// </summary>
    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    /// <summary>
    ///   The subject line of the template, if provided.
    /// </summary>
    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    /// <summary>
    ///   The default text part of messages sent with the template, if provided.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; }

    /// <summary>
    ///   The date and time the template was last modified.
    /// </summary>
    [JsonPropertyName("updated")]
    public DateTime Updated { get; set; }

    /// <summary>
    ///   The full HTML code of the template, with <c>mc:edit</c> attributes
    ///   marking the editable elements.
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    ///   The name of the template.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///   The full HTML code of the template, with <c>mc:edit</c> attributes
    ///   marking the editable elements that are available as published, if
    ///   it has been published.
    /// </summary>
    [JsonPropertyName("publish_code")]
    public string PublishCode { get; set; }

    /// <summary>
    ///   The same as the template name - kept as a separate field for
    ///   backwards compatibility.
    /// </summary>
    /// <seealso cref="Name" />
    [JsonPropertyName("publish_name")]
    public string PublishName { get; set; }

    #endregion
  }
}