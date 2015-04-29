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
using Mandrill.Models.Requests;
using RestSharp;
using Content = Mandrill.Models.Content;

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
    /// <param name="request">
    ///   The request.
    /// </param>
    /// <returns>
    ///   The <see cref="ScheduledEmailResult" />.
    /// </returns>
    public async Task<ScheduledEmailResult> CancelScheduledMessage(CancelScheduledMessageRequest request)
    {
      string path = "/messages/cancel-scheduled.json";

      var resp = await Post<ScheduledEmailResult>(path, request);

      return resp;
    }


    /// <summary>
    ///   Get the full content of a recently sent message.
    /// </summary>
    /// <param name="request">
    ///  The content.
    /// </param>
    /// <returns>
    ///   The <see cref="GetContent" />
    /// </returns>
    public async Task<Content> GetContent(ContentRequest request)
    {
      string path = "/messages/content.json";
      
      var response = await Post<Content>(path, request);

      return response;
    }


    /// <summary>
    /// Get the information for a single recently sent message.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <see cref="Task" />.</returns>
    public async Task<MessageInfo> GetInfo(InfoRequest request)
    {
      string path = "/messages/info.json";
      
      var result = await Post<MessageInfo>(path, request);

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
    ///   The search.
    /// </param>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public async Task<List<SearchResult>> Search(SearchRequest search)
    {
      string path = "/messages/search.json";
      
      var response = await Post<List<SearchResult>>(path, search);

      return response;

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
    public async Task<List<EmailResult>> SendMessage(SendMessageRequest request)
    {
      string path = "/messages/send.json";

      var resp = await Post<List<EmailResult>>(path, request);
      return resp;
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
    public async Task<List<EmailResult>> SendMessageTemplate(SendMessageTemplateRequest request)
    {
      string path = "/messages/send-template.json";

      var resp = await Post<List<EmailResult>>(path, request);
      return resp;
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
    public async Task<List<EmailResult>> SendRawMessage(SendRawMessageRequest request) {
      string path = "/messages/send-raw.json";

      var response = await Post<List<EmailResult>>(path, request);

      return response;
    }

    #endregion
  }
}