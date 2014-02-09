// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Messages.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Threading.Tasks;

    using RestSharp;

    /// <summary>
    ///     The mandrill api.
    /// </summary>
    public partial class MandrillApi : IMandrillApi
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The cancel scheduled message.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        ///     The <see cref="ScheduledEmailResult" />.
        /// </returns>
        public ScheduledEmailResult CancelScheduledMessage(string id)
        {
            string path = "/messages/cancel-scheduled.json";

            dynamic payload = new ExpandoObject();
            payload.id = id;

            Task<IRestResponse> post = this.PostAsync(path, payload);
            return
                post.ContinueWith(
                    p => { return JSON.Parse<ScheduledEmailResult>(p.Result.Content); },
                    TaskContinuationOptions.ExecuteSynchronously).Result;
        }

        /// <summary>
        ///     Get the full content of a recently sent message.
        /// </summary>
        /// <param name="id">
        ///     Unique id of the message to get -- passed as the "_id" field in
        ///     webhooks, send calls, or search calls.
        /// </param>
        /// <returns>
        ///     The <see cref="Content" />
        /// </returns>
        public Content Content(string id)
        {
            return this.ContentAsync(id).Result;
        }

        /// <summary>
        ///     Get the full content of a recently sent message.
        /// </summary>
        /// <param name="id">
        ///     Unique id of the message to get -- passed as the "_id" field in
        ///     webhooks, send calls, or search calls.
        /// </param>
        /// <returns>
        ///     The <see cref="Content" />
        /// </returns>
        public Task<Content> ContentAsync(string id)
        {
            string path = "/messages/content.json";

            dynamic payload = new ExpandoObject();
            payload.id = id;

            Task<IRestResponse> post = this.PostAsync(path, payload);

            return post.ContinueWith(
                p => { return JSON.Parse<Content>(p.Result.Content); },
                TaskContinuationOptions.ExecuteSynchronously);
        }

        /// <summary>
        ///     Send a new search instruction through Mandrill.
        /// </summary>
        /// <param name="info">
        /// </param>
        /// <returns>
        ///     The <see cref="SearchResult" />.
        /// </returns>
        public SearchResult Info(Info info)
        {
            return this.InfoAsync(info).Result;
        }

        /// <summary>
        ///     Send a new info instruction through Mandrill.
        /// </summary>
        /// <param name="info">
        ///     The info.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<SearchResult> InfoAsync(Info info)
        {
            string path = "/messages/info.json";

            dynamic payload = new ExpandoObject();
            payload.id = info.id;

            Task<IRestResponse> post = this.PostAsync(path, payload);

            return post.ContinueWith(
                p => { return JSON.Parse<SearchResult>(p.Result.Content); },
                TaskContinuationOptions.ExecuteSynchronously);
        }

        /// <summary>
        ///     The list scheduled messages.
        /// </summary>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<ScheduledEmailResult> ListScheduledMessages()
        {
            string path = "/messages/list-scheduled.json";

            dynamic payload = new ExpandoObject();
            Task<IRestResponse> post = this.PostAsync(path, payload);
            return
                post.ContinueWith(
                    p => { return JSON.Parse<List<ScheduledEmailResult>>(p.Result.Content); },
                    TaskContinuationOptions.ExecuteSynchronously).Result;
        }

        /// <summary>
        ///     The list scheduled messages.
        /// </summary>
        /// <param name="to">
        ///     The to.
        /// </param>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<ScheduledEmailResult> ListScheduledMessages(string to)
        {
            string path = "/messages/list-scheduled.json";

            dynamic payload = new ExpandoObject();
            payload.to = to;

            Task<IRestResponse> post = this.PostAsync(path, payload);
            return
                post.ContinueWith(
                    p => { return JSON.Parse<List<ScheduledEmailResult>>(p.Result.Content); },
                    TaskContinuationOptions.ExecuteSynchronously).Result;
        }

        /// <summary>
        ///     The reschedule message.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <param name="send_at">
        ///     The send_at.
        /// </param>
        /// <returns>
        ///     The <see cref="ScheduledEmailResult" />.
        /// </returns>
        public ScheduledEmailResult RescheduleMessage(string id, DateTime send_at)
        {
            string path = "/messages/reschedule.json";

            dynamic payload = new ExpandoObject();
            payload.id = id;
            payload.send_at = (send_at == DateTime.MinValue)
                                  ? string.Empty
                                  : send_at.ToString(Configuration.DATE_TIME_FORMAT_STRING);

            Task<IRestResponse> post = this.PostAsync(path, payload);
            return
                post.ContinueWith(
                    p => { return JSON.Parse<ScheduledEmailResult>(p.Result.Content); },
                    TaskContinuationOptions.ExecuteSynchronously).Result;
        }

        /// <summary>
        ///     Send a new search instruction through Mandrill.
        /// </summary>
        /// <param name="search">
        /// </param>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<SearchResult> Search(Search search)
        {
            return this.SearchAsync(search).Result;
        }

        /// <summary>
        ///     Send a new search instruction through Mandrill.
        /// </summary>
        /// <param name="search">
        ///     The search.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<List<SearchResult>> SearchAsync(Search search)
        {
            string path = "/messages/search.json";

            dynamic payload = new ExpandoObject();
            payload.query = search.query;
            payload.date_from = search.date_from;
            payload.date_to = search.date_to;
            payload.tags = search.tags;
            payload.senders = search.senders;
            payload.limit = search.limit;

            Task<IRestResponse> post = this.PostAsync(path, payload);

            return post.ContinueWith(
                p => { return JSON.Parse<List<SearchResult>>(p.Result.Content); },
                TaskContinuationOptions.ExecuteSynchronously);
        }

        /// <summary>
        ///     Send a new transactional message through Mandrill.
        /// </summary>
        /// <param name="recipients">
        /// </param>
        /// <param name="subject">
        /// </param>
        /// <param name="content">
        /// </param>
        /// <param name="from">
        /// </param>
        /// <param name="send_at">
        ///     The send_at.
        /// </param>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<EmailResult> SendMessage(
            IEnumerable<EmailAddress> recipients,
            string subject,
            string content,
            EmailAddress from,
            DateTime send_at = new DateTime())
        {
            return SendMessageAsync(recipients, subject, content, from, send_at).Result;
        }

        /// <summary>
        ///     Send a new transactional message through Mandrill using a template
        /// </summary>
        /// <param name="recipients">
        /// </param>
        /// <param name="subject">
        /// </param>
        /// <param name="from">
        /// </param>
        /// <param name="templateName">
        /// </param>
        /// <param name="templateContents">
        /// </param>
        /// <param name="send_at">
        ///     The send_at.
        /// </param>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<EmailResult> SendMessage(
            IEnumerable<EmailAddress> recipients,
            string subject,
            EmailAddress from,
            string templateName,
            IEnumerable<TemplateContent> templateContents,
            DateTime send_at = new DateTime())
        {
            return this.SendMessageAsync(recipients, subject, from, templateName, templateContents, send_at).Result;
        }

        /// <summary>
        ///     The send message.
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <param name="send_at">
        ///     The send_at.
        /// </param>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<EmailResult> SendMessage(EmailMessage message, DateTime send_at = new DateTime())
        {
            return this.SendMessageAsync(message, send_at).Result;
        }

        /// <summary>
        ///     Send a new transactional message through Mandrill using a template
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <param name="templateName">
        /// </param>
        /// <param name="templateContents">
        /// </param>
        /// <param name="send_at">
        ///     The send_at.
        /// </param>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<EmailResult> SendMessage(
            EmailMessage message,
            string templateName,
            IEnumerable<TemplateContent> templateContents,
            DateTime send_at = new DateTime())
        {
            return SendMessageAsync(message, templateName, templateContents, send_at).Result;
        }

        /// <summary>
        ///     Send a new transactional message through Mandrill.
        /// </summary>
        /// <param name="recipients">
        /// </param>
        /// <param name="subject">
        /// </param>
        /// <param name="content">
        /// </param>
        /// <param name="from">
        /// </param>
        /// <param name="send_at">
        ///     The send_at.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<List<EmailResult>> SendMessageAsync(
            IEnumerable<EmailAddress> recipients,
            string subject,
            string content,
            EmailAddress from,
            DateTime send_at = new DateTime())
        {
            var message = new EmailMessage
                              {
                                  to = recipients,
                                  from_name = from.name,
                                  from_email = from.email,
                                  subject = subject,
                                  html = content,
                                  auto_text = true,
                              };

            return this.SendMessageAsync(message, send_at);
        }

        /// <summary>
        ///     Send a new transactional message through Mandrill using a template
        /// </summary>
        /// <param name="recipients">
        /// </param>
        /// <param name="subject">
        /// </param>
        /// <param name="from">
        /// </param>
        /// <param name="templateName">
        /// </param>
        /// <param name="templateContents">
        /// </param>
        /// <param name="send_at">
        ///     The send_at.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<List<EmailResult>> SendMessageAsync(
            IEnumerable<EmailAddress> recipients,
            string subject,
            EmailAddress from,
            string templateName,
            IEnumerable<TemplateContent> templateContents,
            DateTime send_at = new DateTime())
        {
            var message = new EmailMessage
                              {
                                  to = recipients,
                                  from_name = from.name,
                                  from_email = from.email,
                                  subject = subject,
                              };

            return SendMessageAsync(message, templateName, templateContents, send_at);
        }

        /// <summary>
        ///     Sends a new transactional message through Mandrill.
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <param name="send_at">
        ///     The send_at.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<List<EmailResult>> SendMessageAsync(EmailMessage message, DateTime send_at = new DateTime())
        {
            string path = "/messages/send.json";

            dynamic payload = new ExpandoObject();
            payload.message = message;
            payload.send_at = (send_at == DateTime.MinValue)
                                  ? string.Empty
                                  : send_at.ToString(Configuration.DATE_TIME_FORMAT_STRING);

            Task<IRestResponse> post = this.PostAsync(path, payload);

            return post.ContinueWith(
                p => JSON.Parse<List<EmailResult>>(p.Result.Content),
                TaskContinuationOptions.ExecuteSynchronously);
        }

        /// <summary>
        ///     Send a new transactional message through Mandrill using a template
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <param name="templateName">
        /// </param>
        /// <param name="templateContents">
        /// </param>
        /// <param name="send_at">
        ///     The send_at.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<List<EmailResult>> SendMessageAsync(
            EmailMessage message,
            string templateName,
            IEnumerable<TemplateContent> templateContents,
            DateTime send_at = new DateTime())
        {
            string path = "/messages/send-template.json";

            dynamic payload = new ExpandoObject();
            payload.message = message;
            payload.template_name = templateName;
            payload.template_content = templateContents != null ? templateContents : Enumerable.Empty<TemplateContent>();
            payload.send_at = (send_at == DateTime.MinValue)
                                  ? string.Empty
                                  : send_at.ToString(Configuration.DATE_TIME_FORMAT_STRING);

            Task<IRestResponse> post = this.PostAsync(path, payload);
            return post.ContinueWith(
                p => { return JSON.Parse<List<EmailResult>>(p.Result.Content); },
                TaskContinuationOptions.ExecuteSynchronously);
        }

        /// <summary>
        ///     The send raw message.
        /// </summary>
        /// <param name="raw_message">
        ///     The raw_message.
        /// </param>
        /// <param name="send_at">
        ///     The send_at.
        /// </param>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<EmailResult> SendRawMessage(EmailMessage raw_message, DateTime send_at = new DateTime())
        {
            return this.SendRawMessageAsync(raw_message, send_at).Result;
        }

        /// <summary>
        ///     Send a new raw transactional message through Mandrill using a template
        /// </summary>
        /// <param name="message">
        ///     The message.
        /// </param>
        /// <param name="send_at">
        ///     The send_at.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<List<EmailResult>> SendRawMessageAsync(EmailMessage message, DateTime send_at = new DateTime())
        {
            string path = "/messages/send-raw.json";

            dynamic payload = new ExpandoObject();
            payload.raw_message = message.raw_message;
            payload.from_email = message.from_email;
            payload.from_name = message.from_name;
            payload.send_at = (send_at == DateTime.MinValue)
                                  ? string.Empty
                                  : send_at.ToString(Configuration.DATE_TIME_FORMAT_STRING);

            // payload.to = message.to;  // Does not work as advertised, silently fails with {"email":"Array","status":"invalid"}
            Task<IRestResponse> post = this.PostAsync(path, payload);
            return post.ContinueWith(
                p => { return JSON.Parse<List<EmailResult>>(p.Result.Content); },
                TaskContinuationOptions.ExecuteSynchronously);
        }

        #endregion
    }
}