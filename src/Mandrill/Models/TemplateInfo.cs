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
using Newtonsoft.Json;

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
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///   The default sender address for the template, if provided.
    /// </summary>
    public string FromEmail { get; set; }

    /// <summary>
    ///   The default sender from name for the template, if provided.
    /// </summary>
    public string FromName { get; set; }

    /// <summary>
    ///   The list of labels applied to the template.
    /// </summary>
    public IEnumerable<string> Labels { get; set; }

    /// <summary>
    ///   The default sender address for the template, if provided.
    /// </summary>
    public string PublishFromEmail { get; set; }

    /// <summary>
    ///   The default sender from name for the template, if provided.
    /// </summary>
    public string PublishFromName { get; set; }

    /// <summary>
    ///   The subject line of the template, if provided.
    /// </summary>
    public string PublishSubject { get; set; }

    /// <summary>
    ///   The default text part of messages sent with the template, if
    ///   provided.
    /// </summary>
    public string PublishText { get; set; }

    /// <summary>
    ///   The date and time the template was last published, or null if it
    ///   has not been published.
    /// </summary>
    public DateTime Published { get; set; }

    /// <summary>
    ///   The immutable unique code name of the template.
    /// </summary>
    public string Slug { get; set; }

    /// <summary>
    ///   The subject line of the template, if provided.
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    ///   The default text part of messages sent with the template, if provided.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    ///   The date and time the template was last modified.
    /// </summary>
    public DateTime Updated { get; set; }

    /// <summary>
    ///   The full HTML code of the template, with <c>mc:edit</c> attributes
    ///   marking the editable elements.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    ///   The name of the template.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///   The full HTML code of the template, with <c>mc:edit</c> attributes
    ///   marking the editable elements that are available as published, if
    ///   it has been published.
    /// </summary>
    public string PublishCode { get; set; }

    /// <summary>
    ///   The same as the template name - kept as a separate field for
    ///   backwards compatibility.
    /// </summary>
    /// <seealso cref="Name" />
    public string PublishName { get; set; }

    #endregion
  }
}