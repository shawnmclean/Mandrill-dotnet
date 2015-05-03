// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Messages.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Messages;

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

      ScheduledEmailResult resp = await Post<ScheduledEmailResult>(path, request);

      return resp;
    }


    /// <summary>
    ///   Get the full content of a recently sent message.
    /// </summary>
    /// <param name="request">
    ///   The content.
    /// </param>
    /// <returns>
    ///   The <see cref="GetContent" />
    /// </returns>
    public async Task<Content> GetContent(ContentRequest request)
    {
      string path = "/messages/content.json";

      Content response = await Post<Content>(path, request);

      return response;
    }


    /// <summary>
    ///   Get the information for a single recently sent message.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <see cref="Task" />.</returns>
    public async Task<MessageInfo> GetInfo(MessageInfoRequest request)
    {
      string path = "/messages/info.json";

      MessageInfo result = await Post<MessageInfo>(path, request);

      return result;
    }


    /// <summary>
    ///   The list scheduled messages.
    /// </summary>
    /// <param name="request">
    ///   The request.
    /// </param>
    /// <returns>
    ///   The <see cref="List" />.
    /// </returns>
    public async Task<List<ScheduledEmailResult>> ListScheduledMessages(ListScheduledMessagesRequest request)
    {
      string path = "/messages/list-scheduled.json";

      List<ScheduledEmailResult> resp = await Post<List<ScheduledEmailResult>>(path, request);

      return resp;
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
    public async Task<ScheduledEmailResult> RescheduleMessage(RescheduleMessageRequest request)
    {
      string path = "/messages/reschedule.json";

      ScheduledEmailResult response = await Post<ScheduledEmailResult>(path, request);

      return response;
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

      List<SearchResult> response = await Post<List<SearchResult>>(path, search);

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

      List<EmailResult> resp = await Post<List<EmailResult>>(path, request);
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

      List<EmailResult> resp = await Post<List<EmailResult>>(path, request);
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
    public async Task<List<EmailResult>> SendRawMessage(SendRawMessageRequest request)
    {
      string path = "/messages/send-raw.json";

      List<EmailResult> response = await Post<List<EmailResult>>(path, request);

      return response;
    }

    #endregion
  }
}