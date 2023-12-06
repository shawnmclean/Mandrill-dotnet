// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Templates.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Templates;

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
      string path = "templates/add.json";

      TemplateInfo resp = await Post<TemplateInfo>(path, request).ConfigureAwait(false);

      return resp;
    }

    /// <summary>
    ///   Return a list of all the templates available to this user
    /// </summary>
    /// <returns>
    ///   The <see cref="List" />.
    /// </returns>
    public async Task<List<TemplateInfo>> ListTemplates(ListTemplatesRequest request)
    {
      const string path = "templates/list.json";

      List<TemplateInfo> resp = await Post<List<TemplateInfo>>(path, request).ConfigureAwait(false);

      return resp;
    }

    /// <summary>
    ///   The render async.
    /// </summary>
    /// <param name="request">
    ///   The request.
    /// </param>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public async Task<RenderedTemplate> Render(RenderTemplateRequest request)
    {
      const string path = "templates/render.json";

      RenderedTemplate response = await Post<RenderedTemplate>(path, request).ConfigureAwait(false);

      return response;
    }

    /// <summary>
    ///   Update the code for an existing template, asynchronously.
    /// </summary>
    /// <param name="request">
    ///   The request.
    /// </param>
    /// <remarks>
    ///   If <c>null</c> is provided for any fields, the values will remain unchanged.
    /// </remarks>
    /// <returns>
    ///   The <see cref="TemplateInfo" /> object of the template that was updated
    /// </returns>
    public async Task<TemplateInfo> UpdateTemplate(UpdateTemplateRequest request)
    {
      const string path = "templates/update.json";

      TemplateInfo response = await Post<TemplateInfo>(path, request).ConfigureAwait(false);

      return response;
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
      const string path = "templates/delete.json";

      TemplateInfo response = await Post<TemplateInfo>(path, request).ConfigureAwait(false);

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
    public async Task<TemplateInfo> TemplateInfo(TemplateInfoRequest request)
    {
      const string path = "templates/info.json";

      TemplateInfo response = await Post<TemplateInfo>(path, request).ConfigureAwait(false);

      return response;
    }

    /// <summary>
    ///   Return the recent history (hourly stats for the last 30 days) for a template.
    /// </summary>
    /// <param name="request">
    ///   The request.
    /// </param>
    /// <returns>
    ///   A list of <see cref="TemplateTimeSeries"/> for the template.
    /// </returns>
    public async Task<List<TemplateTimeSeries>> TemplateTimeSeries(TemplateTimeSeriesRequest request)
    {
      const string path = "templates/time-series.json";

      List<TemplateTimeSeries> response = await Post<List<TemplateTimeSeries>>(path, request).ConfigureAwait(false);

      return response;
    }

    #endregion
  }
}