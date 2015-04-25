// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Templates.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Models.Requests;
using RestSharp;

namespace Mandrill
{
  /// <summary>
  ///   The mandrill api.
  /// </summary>
  public partial class MandrillApi
  {
    #region Public Methods and Operators

    /// <summary>
    ///   Add a new template.
    /// </summary>
    /// <param name="name">
    ///   The name for the new template - must be unique.
    /// </param>
    /// <param name="fromEmail">
    ///   A default sending address for emails sent using this template.
    /// </param>
    /// <param name="fromName">A default from name to be used.</param>
    /// <param name="subject">A default subject line to be used.</param>
    /// <param name="code">
    ///   The HTML code for the template with <c>mc:edit</c> attributes for
    ///   the editable elements.
    /// </param>
    /// <param name="text">
    ///   A default text part to be used when sending with this template.
    /// </param>
    /// <param name="publish">
    ///   Set to false to add a draft template without publishing.
    /// </param>
    /// <param name="labels">
    ///   Array of up to 10 labels to use for filtering templates.
    /// </param>
    /// <returns>A <see cref="TemplateResponse" /> object.</returns>
    public TemplateInfo AddTemplate(
      string name,
      string fromEmail,
      string fromName,
      string subject,
      string code,
      string text,
      bool publish,
      IEnumerable<string> labels)
    {
      return AddTemplateAsync(name, fromEmail, fromName, subject, code, text, publish, labels).Result;
    }

    /// <summary>
    ///   Add a new template.
    /// </summary>
    /// <param name="name">
    ///   The name for the new template - must be unique.
    /// </param>
    /// <param name="fromEmail">
    ///   A default sending address for emails sent using this template.
    /// </param>
    /// <param name="fromName">A default from name to be used.</param>
    /// <param name="subject">A default subject line to be used.</param>
    /// <param name="code">
    ///   The HTML code for the template with <c>mc:edit</c> attributes for
    ///   the editable elements.
    /// </param>
    /// <param name="text">
    ///   A default text part to be used when sending with this template.
    /// </param>
    /// <param name="publish">
    ///   Set to false to add a draft template without publishing.
    /// </param>
    /// <returns>A <see cref="TemplateResponse" /> object.</returns>
    public TemplateInfo AddTemplate(
      string name,
      string fromEmail,
      string fromName,
      string subject,
      string code,
      string text,
      bool publish)
    {
      return
        AddTemplateAsync(
          name,
          fromEmail,
          fromName,
          subject,
          code,
          text,
          publish,
          Enumerable.Empty<string>()).Result;
    }

    /// <summary>
    ///   Add a new template asynchronously.
    /// </summary>
    /// <param name="name">
    ///   The name for the new template - must be unique.
    /// </param>
    /// <param name="fromEmail">
    ///   A default sending address for emails sent using this template.
    /// </param>
    /// <param name="fromName">A default from name to be used.</param>
    /// <param name="subject">A default subject line to be used.</param>
    /// <param name="code">
    ///   The HTML code for the template with <c>mc:edit</c> attributes for
    ///   the editable elements.
    /// </param>
    /// <param name="text">
    ///   A default text part to be used when sending with this template.
    /// </param>
    /// <param name="published">
    ///   Set to false to add a draft template without publishing.
    /// </param>
    /// <returns>A <see cref="TemplateResponse" /> object.</returns>
    public Task<TemplateInfo> AddTemplateAsync(
      string name,
      string fromEmail,
      string fromName,
      string subject,
      string code,
      string text,
      bool publish)
    {
      return AddTemplateAsync(
        name,
        fromEmail,
        fromName,
        subject,
        code,
        text,
        publish,
        Enumerable.Empty<string>());
    }

    /// <summary>
    ///   Add a new template asynchronously.
    /// </summary>
    /// <param name="name">
    ///   The name for the new template - must be unique.
    /// </param>
    /// <param name="fromEmail">
    ///   A default sending address for emails sent using this template.
    /// </param>
    /// <param name="fromName">A default from name to be used.</param>
    /// <param name="subject">A default subject line to be used.</param>
    /// <param name="code">
    ///   The HTML code for the template with <c>mc:edit</c> attributes for
    ///   the editable elements.
    /// </param>
    /// <param name="text">
    ///   A default text part to be used when sending with this template.
    /// </param>
    /// <param name="published">
    ///   Set to false to add a draft template without publishing.
    /// </param>
    /// <param name="labels">
    ///   Array of up to 10 labels to use for filtering templates.
    /// </param>
    /// <returns>A <see cref="TemplateResponse" /> object.</returns>
    public Task<TemplateInfo> AddTemplateAsync(
      string name,
      string fromEmail,
      string fromName,
      string subject,
      string code,
      string text,
      bool publish,
      IEnumerable<string> labels)
    {
      const string path = "/templates/add.json";

      dynamic payload = new ExpandoObject();

      payload.name = name;
      payload.from_email = fromEmail;
      payload.from_name = fromName;
      payload.subject = subject;
      payload.code = code;
      payload.text = text;
      payload.publish = publish;

      if (!labels.Equals(Enumerable.Empty<string>()))
      {
        payload.labels = labels;
      }

      Task<IRestResponse> post = PostAsync(path, payload);

      return post.ContinueWith(
        p => { return JSON.Parse<TemplateInfo>(p.Result.Content); },
        TaskContinuationOptions.ExecuteSynchronously);
    }

    /// <summary>
    ///   The list templates.
    /// </summary>
    /// <returns>
    ///   The <see cref="List" />.
    /// </returns>
    public List<TemplateInfo> ListTemplates(string label = "")
    {
      return ListTemplatesAsync(label).Result;
    }

    /// <summary>
    ///   The list templates async.
    /// </summary>
    /// <param name="label">
    ///   The optional label to filter the templates
    /// </param>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public Task<List<TemplateInfo>> ListTemplatesAsync(string label = "")
    {
      const string path = "/templates/list.json";

      dynamic payload = new ExpandoObject();
      payload.label = label;

      Task<IRestResponse> post = PostAsync(path, payload);
      return post.ContinueWith(
        p => JSON.Parse<List<TemplateInfo>>(p.Result.Content),
        TaskContinuationOptions.ExecuteSynchronously);
    }


    /// <summary>
    ///   The render async.
    /// </summary>
    /// <param name="templateName">
    ///   The template name.
    /// </param>
    /// <param name="templateContents">
    ///   The template contents.
    /// </param>
    /// <param name="mergeVars">
    ///   The merge vars.
    /// </param>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public Task<RenderedTemplate> Render(
      string templateName,
      IEnumerable<TemplateContent> templateContents,
      IEnumerable<MergeVar> mergeVars)
    {
      const string path = "/templates/render.json";

      var payload = new RenderRequest();

      payload.TemplateName = templateName;
      payload.TemplateContents = templateContents;
      payload.MergeVars = mergeVars;

      Task<RenderedTemplate> response = Post<RenderedTemplate>(path, payload);

      return response;
    }

    /// <summary>
    ///   Update the code for an existing template.
    /// </summary>
    /// <param name="name">
    ///   The template name.
    /// </param>
    /// <param name="fromEmail">
    ///   A default sending address for emails sent using this template.
    /// </param>
    /// <param name="fromName">A default from name to be used.</param>
    /// <param name="subject">A default subject line to be used.</param>
    /// <param name="code">
    ///   The HTML code for the template with <c>mc:edit</c> attributes for
    ///   the editable elements.
    /// </param>
    /// <param name="text">
    ///   A default text part to be used when sending with this template.
    /// </param>
    /// <param name="publish">
    ///   Set to false to update a draft template without publishing.
    /// </param>
    /// <param name="labels">
    ///   Array of up to 10 labels to use for filtering templates.
    /// </param>
    /// <remarks>
    ///   If <c>null</c> is provided for any fields, the values will remain unchanged.
    /// </remarks>
    /// <returns>
    ///   The <see cref="TemplateInfo" /> object of the template that was updated
    /// </returns>
    public TemplateInfo UpdateTemplate(
      string name,
      string fromEmail,
      string fromName,
      string subject,
      string code,
      string text,
      bool? publish,
      IEnumerable<string> labels)
    {
      return UpdateTemplateAsync(name, fromEmail, fromName, subject, code, text, publish, labels).Result;
    }

    /// <summary>
    ///   Update the code for an existing template, asynchronously.
    /// </summary>
    /// <param name="name">
    ///   The template name.
    /// </param>
    /// <param name="fromEmail">
    ///   A default sending address for emails sent using this template.
    /// </param>
    /// <param name="fromName">A default from name to be used.</param>
    /// <param name="subject">A default subject line to be used.</param>
    /// <param name="code">
    ///   The HTML code for the template with <c>mc:edit</c> attributes for
    ///   the editable elements.
    /// </param>
    /// <param name="text">
    ///   A default text part to be used when sending with this template.
    /// </param>
    /// <param name="publish">
    ///   Set to false to update a draft template without publishing.
    /// </param>
    /// <param name="labels">
    ///   Array of up to 10 labels to use for filtering templates.
    /// </param>
    /// <remarks>
    ///   If <c>null</c> is provided for any fields, the values will remain unchanged.
    /// </remarks>
    /// <returns>
    ///   The <see cref="TemplateInfo" /> object of the template that was updated
    /// </returns>
    public Task<TemplateInfo> UpdateTemplateAsync(
      string name,
      string fromEmail,
      string fromName,
      string subject,
      string code,
      string text,
      bool? publish,
      IEnumerable<string> labels)
    {
      const string path = "/templates/update.json";

      dynamic payload = new ExpandoObject();

      payload.name = name;
      payload.from_email = fromEmail;
      payload.from_name = fromName;
      payload.subject = subject;
      payload.code = code;
      payload.text = text;
      payload.publish = publish;
      payload.labels = labels;

      Task<IRestResponse> post = PostAsync(path, payload);

      return post.ContinueWith(
        p => JSON.Parse<TemplateInfo>(p.Result.Content),
        TaskContinuationOptions.ExecuteSynchronously);
    }

    /// <summary>
    ///   Delete a template.
    /// </summary>
    /// <param name="name">
    ///   The template name.
    /// </param>
    /// <returns>
    ///   The <see cref="TemplateInfo" /> object of the template that was deleted
    /// </returns>
    public TemplateInfo DeleteTemplate(
      string name)
    {
      return DeleteTemplateAsync(name).Result;
    }

    /// <summary>
    ///   Delete a template, asynchronously.
    /// </summary>
    /// <param name="name">
    ///   The template name.
    /// </param>
    /// <returns>
    ///   The <see cref="TemplateInfo" /> object of the template that was deleted
    /// </returns>
    public Task<TemplateInfo> DeleteTemplateAsync(
      string name)
    {
      const string path = "/templates/delete.json";

      dynamic payload = new ExpandoObject();

      payload.name = name;

      Task<IRestResponse> post = PostAsync(path, payload);

      return post.ContinueWith(
        p => JSON.Parse<TemplateInfo>(p.Result.Content),
        TaskContinuationOptions.ExecuteSynchronously);
    }

    /// <summary>
    ///   Fetch a specific template.
    /// </summary>
    /// <param name="name">
    ///   The unique name of the template.
    /// </param>
    /// <returns>
    ///   A <see cref="TemplateInfo" /> object.
    /// </returns>
    public TemplateInfo TemplateInfo(string name)
    {
      return TemplateInfoAsync(name).Result;
    }

    /// <summary>
    ///   Fetch a specific template.
    /// </summary>
    /// <param name="name">
    ///   The unique name of the template.
    /// </param>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public Task<TemplateInfo> TemplateInfoAsync(string name)
    {
      const string path = "/templates/info.json";

      dynamic payload = new ExpandoObject();

      payload.name = name;

      Task<IRestResponse> post = PostAsync(path, payload);

      return post.ContinueWith(
        p => JSON.Parse<TemplateInfo>(p.Result.Content),
        TaskContinuationOptions.ExecuteSynchronously);
    }

    #endregion
  }
}