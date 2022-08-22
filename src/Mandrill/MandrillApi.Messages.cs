// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Messages.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mandrill.Models;
using Mandrill.Requests.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandrill
{
  /// <summary>
  ///   The mandrill api.
  /// </summary>
  public partial class MandrillApi
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
      var path = "messages/cancel-scheduled.json";

      var resp = await Post<ScheduledEmailResult>(path, request).ConfigureAwait(false);

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
      var path = "messages/content.json";

      var response = await Post<Content>(path, request).ConfigureAwait(false);

      return response;
    }


    /// <summary>
    ///   Get the information for a single recently sent message.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <see cref="Task" />.</returns>
    public async Task<MessageInfo> GetInfo(MessageInfoRequest request)
    {
      var path = "messages/info.json";

      var result = await Post<MessageInfo>(path, request).ConfigureAwait(false);

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
      var path = "messages/list-scheduled.json";

      var resp = await Post<List<ScheduledEmailResult>>(path, request).ConfigureAwait(false);

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
      var path = "messages/reschedule.json";

      var response = await Post<ScheduledEmailResult>(path, request).ConfigureAwait(false);

      return response;
    }

    /// <summary>
    /// Search recently sent messages and optionally narrow by date range, tags, senders, and API keys. If no date range is specified,
    /// results within the last 7 days are returned. This method may be called up to 20 times per minute. If you need the data more often,
    /// you can use /messages/info.json to get the information for a single message, or webhooks to push activity to your own application for querying.
    /// <see cref="https://mandrillapp.com/api/docs/messages.JSON.html#method=search">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <see cref="EmailResult"/>.</returns>
    public async Task<List<SearchResult>> Search(SearchRequest request)
    {
      const string path = "messages/search.json";

      var response = await Post<List<SearchResult>>(path, request).ConfigureAwait(false);

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
      var path = "messages/send.json";

      var resp = await Post<List<EmailResult>>(path, request).ConfigureAwait(false);
      return resp;
    }


    /// <summary>
    ///   Send a new transactional message through Mandrill using a template.
    ///   <see cref="https://mandrillapp.com/api/docs/messages.JSON.html#method=send-template">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <see cref="List{T}" />.</returns>
    public async Task<List<EmailResult>> SendMessageTemplate(SendMessageTemplateRequest request)
    {
      var path = "messages/send-template.json";

      var resp = await Post<List<EmailResult>>(path, request).ConfigureAwait(false);
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
      var path = "messages/send-raw.json";

      var response = await Post<List<EmailResult>>(path, request).ConfigureAwait(false);

      return response;
    }

    #endregion
  }
}