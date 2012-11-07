using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Mandrill.Models;
using RestSharp;

namespace Mandrill
{
    public partial class MandrillApi
    {
        public RenderedTemplate Render(string templateName, IEnumerable<TemplateContent> templateContents, IEnumerable<merge_var> mergeVars)
        {
            return RenderAsync(templateName, templateContents, mergeVars).Result;
        }

        public Task<RenderedTemplate> RenderAsync(string templateName, IEnumerable<TemplateContent> templateContents, IEnumerable<merge_var> mergeVars)
        {
            const string path = "/templates/render.json";

            dynamic payload = new ExpandoObject();

            payload.template_name = templateName;
            payload.template_content = templateContents;
            payload.merge_vars = mergeVars;

            Task<IRestResponse> post = PostAsync(path, payload);

            return post.ContinueWith(p =>
            {
                return JSON.Parse<RenderedTemplate>(p.Result.Content);
            }, TaskContinuationOptions.ExecuteSynchronously);
        }

        public Task<List<TemplateInfo>> ListTemplatesAsync()
        {
            const string path = "/templates/list.json";

            return this.PostAsync(path, null).ContinueWith(
                p => JSON.Parse<List<TemplateInfo>>(p.Result.Content),
                TaskContinuationOptions.ExecuteSynchronously);
        }

        public List<TemplateInfo> ListTemplates()
        {
            return this.ListTemplatesAsync().Result;
        }
    }
}
