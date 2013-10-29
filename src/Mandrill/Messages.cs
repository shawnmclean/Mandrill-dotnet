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
        public List<EmailResult> SendMessage(IEnumerable<EmailAddress> recipients, string subject, string content, EmailAddress from, DateTime send_at = new DateTime())
        {
            return SendMessageAsync(recipients, subject, content, from, send_at).Result;
        }


        /// <summary>
        /// Send a new transactional message through Mandrill.
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public Task<List<EmailResult>> SendMessageAsync(IEnumerable<EmailAddress> recipients, string subject, string content, EmailAddress from, DateTime send_at = new DateTime())
        {
            var message = new EmailMessage()
            {
                to = recipients,
                from_name = from.name,
                from_email = from.email,
                subject = subject,
                html = content,
                auto_text = true,
            };

            return SendMessageAsync(message, send_at);
        }

        /// <summary>
        /// Send a new search instruction through Mandrill.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public SearchResult Info(Info info)
        {
            return InfoAsync(info).Result;
        }

        /// <summary>
        /// Send a new info instruction through Mandrill.
        /// </summary>
        /// <returns></returns>
        public Task<SearchResult> InfoAsync(Info info)
        {
            var path = "/messages/info.json";

            dynamic payload = new ExpandoObject();
            payload.id = info.id;

            Task<IRestResponse> post = PostAsync(path, payload);

            return post.ContinueWith(p =>
            {
                return JSON.Parse<SearchResult>(p.Result.Content);
            }, TaskContinuationOptions.ExecuteSynchronously);
        }


        /// <summary>
        /// Send a new search instruction through Mandrill.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<SearchResult> Search(Search search)
        {
            return SearchAsync(search).Result;
        }

        /// <summary>
        /// Send a new search instruction through Mandrill.
        /// </summary>
        /// <returns></returns>
        public Task<List<SearchResult>> SearchAsync(Search search)
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
        public List<EmailResult> SendMessage(IEnumerable<EmailAddress> recipients, string subject, EmailAddress from, string templateName, IEnumerable<TemplateContent> templateContents, DateTime send_at = new DateTime())
        {
            return SendMessageAsync(recipients, subject, from, templateName, templateContents, send_at).Result;
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
        public Task<List<EmailResult>> SendMessageAsync(IEnumerable<EmailAddress> recipients, string subject, EmailAddress from, string templateName, IEnumerable<TemplateContent> templateContents, DateTime send_at = new DateTime())
        {
            var message = new EmailMessage()
            {
                to = recipients,
                from_name = from.name,
                from_email = from.email,
                subject = subject,
            };

            return SendMessageAsync(message, templateName, templateContents, send_at);
        }

        public List<EmailResult> SendMessage(EmailMessage message, DateTime send_at = new DateTime())
        {
            return SendMessageAsync(message, send_at).Result;
        }

        public List<EmailResult> SendRawMessage(EmailMessage raw_message, DateTime send_at = new DateTime())
        {
            return SendRawMessageAsync(raw_message, send_at).Result;
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
        public List<EmailResult> SendMessage(EmailMessage message, string templateName, IEnumerable<TemplateContent> templateContents, DateTime send_at = new DateTime())
        {
            return SendMessageAsync(message, templateName, templateContents, send_at).Result;
        }

        /// <summary>
        /// Sends a new transactional message through Mandrill.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Task<List<EmailResult>> SendMessageAsync(EmailMessage message, DateTime send_at = new DateTime())
        {
            var path = "/messages/send.json";

            dynamic payload = new ExpandoObject();
            payload.message = message;
            payload.send_at = (send_at == DateTime.MinValue) ? "" : send_at.ToString(Configuration.DATE_TIME_FORMAT_STRING);

            Task<IRestResponse> post = PostAsync(path, payload);

            return post.ContinueWith(p => JSON.Parse<List<EmailResult>>(p.Result.Content), TaskContinuationOptions.ExecuteSynchronously);
        }

        /// <summary>
        /// Send a new transactional message through Mandrill using a template
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="templateContents"></param>
        /// <returns></returns>
        public Task<List<EmailResult>> SendMessageAsync(EmailMessage message, string templateName, IEnumerable<TemplateContent> templateContents, DateTime send_at = new DateTime())
        {
            var path = "/messages/send-template.json";

            dynamic payload = new ExpandoObject();
            payload.message = message;
            payload.template_name = templateName;
            payload.template_content = templateContents != null ? templateContents : Enumerable.Empty<TemplateContent>();
            payload.send_at = (send_at == DateTime.MinValue) ? "" : send_at.ToString(Configuration.DATE_TIME_FORMAT_STRING);

            Task<IRestResponse> post = PostAsync(path, payload);
            return post.ContinueWith(p =>
            {
                return JSON.Parse<List<EmailResult>>(p.Result.Content);
            }, TaskContinuationOptions.ExecuteSynchronously);
        }

        /// <summary>
        /// Send a new raw transactional message through Mandrill using a template
        /// </summary>
        public Task<List<EmailResult>> SendRawMessageAsync(EmailMessage message, DateTime send_at = new DateTime())
        {
            var path = "/messages/send-raw.json";

            dynamic payload = new ExpandoObject();
            payload.raw_message = message.raw_message;
            payload.from_email = message.from_email;
            payload.from_name = message.from_name;
            payload.send_at = (send_at == DateTime.MinValue) ? "" : send_at.ToString(Configuration.DATE_TIME_FORMAT_STRING);
            //payload.to = message.to;  // Does not work as advertised, silently fails with {"email":"Array","status":"invalid"}

            Task<IRestResponse> post = PostAsync(path, payload);
            return post.ContinueWith(p =>
            {
                return JSON.Parse<List<EmailResult>>(p.Result.Content);
            }, TaskContinuationOptions.ExecuteSynchronously);
        }

        public List<ScheduledEmailResult> ListScheduledMessages()
        {
            var path = "/messages/list-scheduled.json";

            dynamic payload = new ExpandoObject();
            Task<IRestResponse> post = PostAsync(path, payload);
            return post.ContinueWith(p =>
                {
                    return JSON.Parse<List<ScheduledEmailResult>>(p.Result.Content);
                }, TaskContinuationOptions.ExecuteSynchronously).Result;
        }

        public List<ScheduledEmailResult> ListScheduledMessages(string to)
        {
            var path = "/messages/list-scheduled.json";

            dynamic payload = new ExpandoObject();
            payload.to = to;

            Task<IRestResponse> post = PostAsync(path, payload);
            return post.ContinueWith(p =>
            {
                return JSON.Parse<List<ScheduledEmailResult>>(p.Result.Content);
            }, TaskContinuationOptions.ExecuteSynchronously).Result;
        }

        public ScheduledEmailResult CancelScheduledMessage(string id)
        {
            var path = "/messages/cancel-scheduled.json";

            dynamic payload = new ExpandoObject();
            payload.id = id;

            Task<IRestResponse> post = PostAsync(path, payload);
            return post.ContinueWith(p =>
            {
                return JSON.Parse<ScheduledEmailResult>(p.Result.Content);
            }, TaskContinuationOptions.ExecuteSynchronously).Result;
        }

        public ScheduledEmailResult RescheduleMessage(string id, DateTime send_at)
        {
            var path = "/messages/reschedule.json";

            dynamic payload = new ExpandoObject();
            payload.id = id;
            payload.send_at = (send_at == DateTime.MinValue) ? "" : send_at.ToString(Configuration.DATE_TIME_FORMAT_STRING);

            Task<IRestResponse> post = PostAsync(path, payload);
            return post.ContinueWith(p =>
            {
                return JSON.Parse<ScheduledEmailResult>(p.Result.Content);
            }, TaskContinuationOptions.ExecuteSynchronously).Result;
        }
    }
}
