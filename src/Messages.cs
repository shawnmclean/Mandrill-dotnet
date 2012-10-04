using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Mandrill
{
    public partial class MandrillApi
    {        
        /// <summary>
        /// Send a new transactional message through Mandrill.
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public List<EmailResult> SendMessage(IEnumerable<EmailAddress> recipients, string subject, string content, EmailAddress from)
        {
            return SendMessageAsync(recipients, subject, content, from).Result;
        }


        /// <summary>
        /// Send a new transactional message through Mandrill.
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public Task<List<EmailResult>> SendMessageAsync(IEnumerable<EmailAddress> recipients, string subject, string content, EmailAddress from)
        {
            var path = "/messages/send.json";

            var message = new EmailMessage()
            {
                to = recipients,
                from_name = from.name,
                from_email = from.email,
                subject = subject,
                html = content,
                auto_text = true,
            };

            dynamic payload = new ExpandoObject();
            payload.message = message;
            
            Task<IRestResponse> post = PostAsync(path, payload);

            return post.ContinueWith(p =>
            {
                return JSON.Parse<List<EmailResult>>(p.Result.Content);
            }, TaskContinuationOptions.ExecuteSynchronously);            
        }

        /// <summary>
        /// Send a new search instruction through Mandrill.
        /// </summary>
        /// <returns></returns>
        public Task<List<SearchResult>> Search(Search search)
        {
            var path = "/messages/search.json";

            dynamic payload = new ExpandoObject();
            payload.query = search.query;
            payload.date_from = search.date_from;
            payload.date_to = search.date_to;
            payload.tags = search.tags;
            payload.senders = search.senders;
            payload.limit = search.limit;

            Task<IRestResponse> post = PostAsync(path, payload);

            return post.ContinueWith(p =>
            {
                return JSON.Parse<List<SearchResult>>(p.Result.Content);
            }, TaskContinuationOptions.ExecuteSynchronously);
        }
        /// <summary>
        /// Send a new transactional message through Mandrill using a template
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="from"></param>
        /// <param name="templateName"></param>
        /// <param name="templateContents"></param>
        /// <returns></returns>
        public List<EmailResult> SendMessage(IEnumerable<EmailAddress> recipients, string subject, EmailAddress from, string templateName, IEnumerable<TemplateContent> templateContents)
        {
            return SendMessageAsync(recipients, subject, from, templateName, templateContents).Result;
        }

        /// <summary>
        /// Send a new transactional message through Mandrill using a template
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="from"></param>
        /// <param name="templateName"></param>
        /// <param name="templateContents"></param>
        /// <returns></returns>
        public Task<List<EmailResult>> SendMessageAsync(IEnumerable<EmailAddress> recipients, string subject, EmailAddress from, string templateName, IEnumerable<TemplateContent> templateContents)
        {
            var message = new EmailMessage()
            {
                to = recipients,
                from_name = from.name,
                from_email = from.email,
                subject = subject,
            };

            return SendMessageAsync(message, templateName, templateContents);
        }



        /// <summary>
        /// Send a new transactional message through Mandrill using a template
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="from"></param>
        /// <param name="templateName"></param>
        /// <param name="templateContents"></param>
        /// <returns></returns>
        public List<EmailResult> SendMessage(EmailMessage message, string templateName, IEnumerable<TemplateContent> templateContents)
        {
            return SendMessageAsync(message, templateName, templateContents).Result;
        }

        /// <summary>
        /// Send a new transactional message through Mandrill using a template
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="from"></param>
        /// <param name="templateName"></param>
        /// <param name="templateContents"></param>
        /// <returns></returns>
        public Task<List<EmailResult>> SendMessageAsync(EmailMessage message, string templateName, IEnumerable<TemplateContent> templateContents)
        {
            var path = "/messages/send-template.json";

            dynamic payload = new ExpandoObject();
            payload.message = message;
            payload.template_name = templateName;
            payload.template_content = templateContents != null ? templateContents : Enumerable.Empty<TemplateContent>();

            Task<IRestResponse> post = PostAsync(path, payload);
            return post.ContinueWith(p =>
            {
                return JSON.Parse<List<EmailResult>>(p.Result.Content);
            }, TaskContinuationOptions.ExecuteSynchronously);
        }       

    }
}