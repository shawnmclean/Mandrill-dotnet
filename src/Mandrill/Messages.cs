// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Messages.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Models.Payloads;
using RestSharp;

namespace Mandrill
{
  /// <summary>
  ///   The mandrill api.
  /// </summary>
  public partial class MandrillApi : IMandrillApi
  {
    #region Public Methods and Operators

    /// <summary>
    ///   The cancel scheduled message.
    /// </summary>
    /// <param name="id">
    ///   The id.
    /// </param>
    /// <returns>
    ///   The <see cref="ScheduledEmailResult" />.
    /// </returns>
    public ScheduledEmailResult CancelScheduledMessage(string id)
    {
      string path = "/messages/cancel-scheduled.json";

      dynamic payload = new ExpandoObject();
      payload.id = id;

      Task<IRestResponse> post = PostAsync(path, payload);
      return
        post.ContinueWith(
          p => { return JSON.Parse<ScheduledEmailResult>(p.Result.Content); },
          TaskContinuationOptions.ExecuteSynchronously).Result;
    }


    /// <summary>
    ///   Get the full content of a recently sent message.
    /// </summary>
    /// <param name="id">
    ///   Unique id of the message to get -- passed as the "_id" field in
    ///   webhooks, send calls, or search calls.
    /// </param>
    /// <returns>
    ///   The <see cref="Content" />
    /// </returns>
    public async Task<Content> Content(string id)
    {
      string path = "/messages/content.json";

      var payload = new GetContentPayload {Id = id};

      var response = await Post<Content>(path, payload);

      return response;
    }

    /// <summary>
    ///   Get the information for a single recently sent message
    /// </summary>
    /// <param name="id">
    ///   The id.
    /// </param>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public async Task<MessageInfo> Info(string id)
    {
      string path = "/messages/info.json";

      var payload = new InfoPayload {Id = id};

      var result = await Post<MessageInfo>(path, payload);

      return result;
    }

    /// <summary>
    ///   The list scheduled messages.
    /// </summary>
    /// <returns>
    ///   The <see cref="List" />.
    /// </returns>
    public List<ScheduledEmailResult> ListScheduledMessages()
    {
      string path = "/messages/list-scheduled.json";

      dynamic payload = new ExpandoObject();
      Task<IRestResponse> post = PostAsync(path, payload);
      return
        post.ContinueWith(
          p => { return JSON.Parse<List<ScheduledEmailResult>>(p.Result.Content); },
          TaskContinuationOptions.ExecuteSynchronously).Result;
    }

    /// <summary>
    ///   The list scheduled messages.
    /// </summary>
    /// <param name="to">
    ///   The to.
    /// </param>
    /// <returns>
    ///   The <see cref="List" />.
    /// </returns>
    public List<ScheduledEmailResult> ListScheduledMessages(string to)
    {
      string path = "/messages/list-scheduled.json";

      dynamic payload = new ExpandoObject();
      payload.to = to;

      Task<IRestResponse> post = PostAsync(path, payload);
      return
        post.ContinueWith(
          p => { return JSON.Parse<List<ScheduledEmailResult>>(p.Result.Content); },
          TaskContinuationOptions.ExecuteSynchronously).Result;
    }

    /// <summary>
    ///   The reschedule message.
    /// </summary>
    /// <param name="id">
    ///   The id.
    /// </param>
    /// <param name="send_at">
    ///   The send_at.
    /// </param>
    /// <returns>
    ///   The <see cref="ScheduledEmailResult" />.
    /// </returns>
    public ScheduledEmailResult RescheduleMessage(string id, DateTime? send_at)
    {
      string path = "/messages/reschedule.json";

      dynamic payload = new ExpandoObject();
      payload.id = id;

      if (send_at != null)
      {
        payload.send_at = send_at.Value.ToString(Configuration.DATE_TIME_FORMAT_STRING);
      }

      Task<IRestResponse> post = PostAsync(path, payload);
      return
        post.ContinueWith(
          p => { return JSON.Parse<ScheduledEmailResult>(p.Result.Content); },
          TaskContinuationOptions.ExecuteSynchronously).Result;
    }

    /// <summary>
    ///   Send a new search instruction through Mandrill.
    /// </summary>
    /// <param name="search">
    /// </param>
    /// <returns>
    ///   The <see cref="List" />.
    /// </returns>
    public List<SearchResult> Search(Search search)
    {
      return SearchAsync(search).Result;
    }

    /// <summary>
    ///   Send a new search instruction through Mandrill.
    /// </summary>
    /// <param name="search">
    ///   The search.
    /// </param>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public Task<List<SearchResult>> SearchAsync(Search search)
    {
      string path = "/messages/search.json";

      dynamic payload = new ExpandoObject();
      payload.query = search.Query;
      payload.date_from = search.DateFrom;
      payload.date_to = search.DateTo;
      payload.tags = search.Tags;
      payload.senders = search.Senders;
      payload.limit = search.Limit;

      Task<IRestResponse> post = PostAsync(path, payload);

      return post.ContinueWith(
        p => { return JSON.Parse<List<SearchResult>>(p.Result.Content); },
        TaskContinuationOptions.ExecuteSynchronously);
    }

    /// <summary>
    ///   Send a new transactional message through Mandrill.
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
    ///   The send_at.
    /// </param>
    /// <returns>
    ///   The <see cref="List" />.
    /// </returns>
    public List<EmailResult> SendMessage(IEnumerable<EmailAddress> recipients, string subject,
      string content, EmailAddress from, DateTime? send_at = null, bool async = false)
    {
      return SendMessageAsync(recipients, subject, content, from, send_at, async).Result;
    }

    /// <summary>
    ///   Send a new transactional message through Mandrill using a template
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
    ///   The send_at.
    /// </param>
    /// <returns>
    ///   The <see cref="List" />.
    /// </returns>
    public List<EmailResult> SendMessage(
      IEnumerable<EmailAddress> recipients,
      string subject,
      EmailAddress from,
      string templateName,
      IEnumerable<TemplateContent> templateContents,
      DateTime? send_at = null,
      bool async = false)
    {
      return SendMessageAsync(recipients, subject, from, templateName, templateContents, send_at, async).Result;
    }


    /// <summary>
    ///   Send a new transactional message through Mandrill.
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
    ///   The send_at.
    /// </param>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public Task<List<EmailResult>> SendMessageAsync(IEnumerable<EmailAddress> recipients, string subject,
      string content, EmailAddress from, DateTime? send_at = null, bool async = false)
    {
      var message = new EmailMessage
      {
        To = recipients,
        FromName = from.Name,
        FromEmail = from.Email,
        Subject = subject,
        Html = content,
        AutoText = true,
      };

      return SendMessage(message, send_at, async);
    }

    /// <summary>
    ///   Send a new transactional message through Mandrill using a template
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
    ///   The send_at.
    /// </param>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public Task<List<EmailResult>> SendMessageAsync(
      IEnumerable<EmailAddress> recipients,
      string subject,
      EmailAddress from,
      string templateName,
      IEnumerable<TemplateContent> templateContents,
      DateTime? send_at = null,
      bool async = false)
    {
      var message = new EmailMessage
      {
        To = recipients,
        FromName = from.Name,
        FromEmail = from.Email,
        Subject = subject,
      };

      return SendMessage(message, templateName, templateContents, send_at, async);
    }

    /// <summary>
    ///   Sends a new transactional message through Mandrill.
    /// </summary>
    /// <param name="message">
    ///   The message.
    /// </param>
    /// <param name="send_at">
    ///   The send_at.
    /// </param>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public async Task<List<EmailResult>> SendMessage(EmailMessage message, DateTime? send_at = null,
      bool async = false)
    {
      string path = "/messages/send.json";

      var payload = new SendMessagePayload();
      payload.Message = message;
      payload.Async = async;
      if (send_at != null)
      {
        payload.SendAt = send_at.Value.ToString(Configuration.DATE_TIME_FORMAT_STRING);
      }

      Task<List<EmailResult>> resp = Post<List<EmailResult>>(path, payload);
      return await resp;
    }


    /// <summary>
    ///   Send a new transactional message through Mandrill using a template
    /// </summary>
    /// <param name="message">
    ///   The message.
    /// </param>
    /// <param name="templateName">
    /// </param>
    /// <param name="templateContents">
    /// </param>
    /// <param name="send_at">
    ///   The send_at.
    /// </param>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public async Task<List<EmailResult>> SendMessage(
      EmailMessage message,
      string templateName,
      IEnumerable<TemplateContent> templateContents,
      DateTime? send_at = null,
      bool async = false)
    {
      string path = "/messages/send-template.json";

      var payload = new SendMessagePayload();
      payload.Message = message;
      payload.TemplateName = templateName;
      payload.TemplateContents = templateContents != null ? templateContents : Enumerable.Empty<TemplateContent>();
      payload.Async = async;
      if (send_at != null)
      {
        payload.SendAt = send_at.Value.ToString(Configuration.DATE_TIME_FORMAT_STRING);
      }

      Task<List<EmailResult>> resp = Post<List<EmailResult>>(path, payload);
      return await resp;
    }

    /// <summary>
    ///   The send raw message.
    /// </summary>
    /// <param name="raw_message">
    ///   The raw_message.
    /// </param>
    /// <param name="send_at">
    ///   The send_at.
    /// </param>
    /// <returns>
    ///   The <see cref="List" />.
    /// </returns>
    public List<EmailResult> SendRawMessage(EmailMessage raw_message, DateTime? send_at = null, bool async = false)
    {
      return SendRawMessageAsync(raw_message, send_at, async).Result;
    }

    /// <summary>
    ///   Send a new raw message through Mandrill.
    /// </summary>
    /// <param name="message">
    ///   The message.
    /// </param>
    /// <param name="send_at">
    ///   The send_at.
    /// </param>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public Task<List<EmailResult>> SendRawMessageAsync(EmailMessage message, DateTime? send_at = null,
      bool async = false)
    {
      string path = "/messages/send-raw.json";

      dynamic payload = new ExpandoObject();
      payload.raw_message = message.RawMessage;
      payload.from_email = message.FromEmail;
      payload.from_name = message.FromName;
      payload.async = async;
      if (send_at != null)
      {
        payload.send_at = send_at.Value.ToString(Configuration.DATE_TIME_FORMAT_STRING);
      }

      payload.to = message.RawTo;
      Task<IRestResponse> post = PostAsync(path, payload);
      return post.ContinueWith(
        p => { return JSON.Parse<List<EmailResult>>(p.Result.Content); },
        TaskContinuationOptions.ExecuteSynchronously);
    }

    #endregion
  }
}