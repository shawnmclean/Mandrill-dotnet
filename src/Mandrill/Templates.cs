// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Templates.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Threading.Tasks;

    using Mandrill.Models;

    using RestSharp;

    /// <summary>
    /// The mandrill api.
    /// </summary>
    public partial class MandrillApi
    {
        #region Public Methods and Operators

        /// <summary>
        /// The list templates.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<TemplateInfo> ListTemplates()
        {
            return this.ListTemplatesAsync().Result;
        }

        /// <summary>
        /// The list templates async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<List<TemplateInfo>> ListTemplatesAsync()
        {
            const string path = "/templates/list.json";

            return this.PostAsync(path, null)
                .ContinueWith(
                    p => JSON.Parse<List<TemplateInfo>>(p.Result.Content), 
                    TaskContinuationOptions.ExecuteSynchronously);
        }

        /// <summary>
        /// The render.
        /// </summary>
        /// <param name="templateName">
        /// The template name.
        /// </param>
        /// <param name="templateContents">
        /// The template contents.
        /// </param>
        /// <param name="mergeVars">
        /// The merge vars.
        /// </param>
        /// <returns>
        /// The <see cref="RenderedTemplate"/>.
        /// </returns>
        public RenderedTemplate Render(
            string templateName, 
            IEnumerable<TemplateContent> templateContents, 
            IEnumerable<merge_var> mergeVars)
        {
            return this.RenderAsync(templateName, templateContents, mergeVars).Result;
        }

        /// <summary>
        /// The render async.
        /// </summary>
        /// <param name="templateName">
        /// The template name.
        /// </param>
        /// <param name="templateContents">
        /// The template contents.
        /// </param>
        /// <param name="mergeVars">
        /// The merge vars.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<RenderedTemplate> RenderAsync(
            string templateName, 
            IEnumerable<TemplateContent> templateContents, 
            IEnumerable<merge_var> mergeVars)
        {
            const string path = "/templates/render.json";

            dynamic payload = new ExpandoObject();

            payload.template_name = templateName;
            payload.template_content = templateContents;
            payload.merge_vars = mergeVars;

            Task<IRestResponse> post = this.PostAsync(path, payload);

            return post.ContinueWith(
                p => { return JSON.Parse<RenderedTemplate>(p.Result.Content); }, 
                TaskContinuationOptions.ExecuteSynchronously);
        }

        public object AddTemplate(object data)
        {
            return this.AddTemplateAsync(data).Result;
        }

        public Task<object> AddTemplateAsync(object data)
        {
            const string path = "/templates/add.json";
            return this.PostAsync(path, data).ContinueWith(
                p => JSON.Parse<object>(p.Result.Content),
                TaskContinuationOptions.ExecuteSynchronously);
        }

        public object UpdateTemplate(object data)
        {
            return this.UpdateTemplateAsync(data).Result;
        }

        public Task<object> UpdateTemplateAsync(object data)
        {
            const string path = "/templates/update.json";
            return this.PostAsync(path, data).ContinueWith(
                p => JSON.Parse<object>(p.Result.Content),
                TaskContinuationOptions.ExecuteSynchronously);
        }

        #endregion
    }
}