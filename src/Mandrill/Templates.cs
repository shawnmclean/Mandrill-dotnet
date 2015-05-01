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
    /// <param name="request">
    ///   The name for the new template - must be unique.
    /// </param>
    /// <returns>A <see cref="TemplateInfo" /> object.</returns>
    public async Task<TemplateInfo> AddTemplate(AddTemplateRequest request)
    {
      var path = "/templates/add.json";

      var resp = await Post<TemplateInfo>(path, request);

      return resp;
    }
    /// <summary>
    ///   Return a list of all the templates available to this user
    /// </summary>
    /// <returns>
    ///   The <see cref="List" />.
    /// </returns>
    public async Task<List<TemplateInfo>> ListTemplates(ListTemplatesRequest request) {
      const string path = "/templates/list.json";

      var resp = await Post<List<TemplateInfo>>(path, request);

      return resp;
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
    /// <param name="request">
    ///   The template name.
    /// </param>
    /// <returns>
    ///   The <see cref="TemplateInfo" /> object of the template that was deleted
    /// </returns>
    public async Task<TemplateInfo> DeleteTemplate(DeleteTemplateRequest request)
    {
      const string path = "/templates/delete.json";

      var response = await Post<TemplateInfo>(path, request);

      return response;
    }

    /// <summary>
    ///   Fetch a specific template.
    /// </summary>
    /// <param name="request">
    ///   The request.
    /// </param>
    /// <returns>
    ///   A <see cref="TemplateInfo" /> object.
    /// </returns>
    public async Task<TemplateInfo> TemplateInfo(TemplateInfoRequest request) {
      const string path = "/templates/info.json";

      var response = await Post<TemplateInfo>(path, request);

      return response;
    }

    #endregion
  }
}