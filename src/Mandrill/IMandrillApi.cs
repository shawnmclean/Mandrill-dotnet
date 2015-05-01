using Mandrill.Models.Requests;

namespace Mandrill
{
  using System;
  using System.Collections.Generic;
  using System.Net;
  using System.Threading.Tasks;

  using Mandrill.Models;

  public interface IMandrillApi
  {
    /// <summary>
    ///     The cancel scheduled message.
    /// </summary>
    /// <param name="request">
    ///     The request.
    /// </param>
    /// <returns>
    ///     The <see cref="ScheduledEmailResult" />.
    /// </returns>
    Task<ScheduledEmailResult> CancelScheduledMessage(CancelScheduledMessageRequest request);


    /// <summary>
    ///     Get the full content of a recently sent message.
    /// </summary>
    /// <param name="request">
    ///    The request
    /// </param>
    /// <returns>
    ///     The <see cref="MandrillApi.GetContent" />
    /// </returns>
    Task<Content> GetContent(ContentRequest request);


    /// <summary>
    ///     Get the information for a single recently sent message.
    /// </summary>
    /// <param name="request">
    ///     The request.
    /// </param>
    /// <returns>
    ///     The <see cref="Task" />.
    /// </returns>
    Task<MessageInfo> GetInfo(MessageInfoRequest request);

    /// <summary>
    ///     The list scheduled messages.
    /// </summary>
    /// <param name="request">
    ///     The request.
    /// </param>
    /// <returns>
    ///     The <see cref="List{T}" />.
    /// </returns>
    Task<List<ScheduledEmailResult>> ListScheduledMessages(ListScheduledMessagesRequest request);

    /// <summary>
    ///     The reschedule message.
    /// </summary>
    /// <param name="request">
    ///     The request.
    /// </param>
    /// <returns>
    ///     The <see cref="ScheduledEmailResult" />.
    /// </returns>
    Task<ScheduledEmailResult> RescheduleMessage(RescheduleMessageRequest request);

    /// <summary>
    ///     Send a new search instruction through Mandrill.
    /// </summary>
    /// <param name="search">
    ///     The search.
    /// </param>
    /// <returns>
    ///     The <see cref="Task" />.
    /// </returns>
    Task<List<SearchResult>> Search(SearchRequest search);

    /// <summary>
    /// Send a new transactional message through Mandrill using a template
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <see cref="List{T}" />.</returns>
    Task<List<EmailResult>> SendMessageTemplate(SendMessageTemplateRequest request);

    /// <summary>
    ///     Sends a new transactional message through Mandrill.
    /// </summary>
    /// <param name="request">
    ///     The request.
    /// </param>
    /// <returns>
    ///     The <see cref="Task" />.
    /// </returns>
    Task<List<EmailResult>> SendMessage(SendMessageRequest request);


    /// <summary>
    /// Sends the raw message.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>Task&lt;List&lt;EmailResult&gt;&gt;.</returns>
    Task<List<EmailResult>> SendRawMessage(SendRawMessageRequest request);


    /// <summary>
    ///     The Api Key for the project received from the MandrillApp website
    /// </summary>
    string ApiKey { get; }

    IWebProxy Proxy { get; set; }

    /// <summary>
    ///     UserAgent to use for requests.
    /// </summary>
    string UserAgent { get; set; }

    /// <summary>
    ///     The list senders.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>
    ///     a <see cref="SenderDomain" />
    /// </returns>
    Task<SenderDomain> CheckSenderDomain(SenderCheckDomainRequest request);

    /// <summary>
    ///     The list senders.
    /// </summary>
    /// <returns>
    ///     The <see cref="List{T}" />.
    /// </returns>
    Task<List<Sender>> ListSenders();

    /// <summary>
    ///     The list senders.
    /// </summary>
    /// <returns>
    ///     The <see cref="List{T}" />.
    /// </returns>
    Task<List<SenderDomain>> SenderDomains();

    /// <summary>
    ///     Add a new template.
    /// </summary>
    /// <param name="request">
    ///     The name for the new template - must be unique.
    /// </param>
    /// <returns>A <see cref="TemplateInfo" /> object.</returns>
    Task<TemplateInfo> AddTemplate(AddTemplateRequest request);


    /// <summary>
    ///     The list templates.
    /// </summary>
    /// <returns>
    ///     The <see cref="List{T}" />.
    /// </returns>
    Task<List<TemplateInfo>> ListTemplates(ListTemplatesRequest request);

    /// <summary>
    ///     The render async.
    /// </summary>
    /// <param name="request">
    ///     The request.
    /// </param>
    /// <returns>
    ///     The <see cref="Task" />.
    /// </returns>
    Task<RenderedTemplate> Render(RenderTemplateRequest request);

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
    Task<TemplateInfo> UpdateTemplate(UpdateTemplateRequest request);

    /// <summary>
    /// Templates the information.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>Task&lt;TemplateInfo&gt;.</returns>
    Task<TemplateInfo> TemplateInfo(TemplateInfoRequest request);
    /// <summary>
    ///     Delete a template, asynchronously.
    /// </summary>
    /// <param name="request">
    ///     The template name.
    /// </param>
    /// <returns>
    ///     The <see cref="TemplateInfo"/> object of the template that was deleted
    /// </returns>
    Task<TemplateInfo> DeleteTemplate(DeleteTemplateRequest request);

    /// <summary>
    ///     Add a new subaccount.
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=add">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="subaccount">The subaccount to add</param>
    /// <param name="notes">Optional extra text to associate with the subaccount</param>
    /// <returns>the information saved about the new subaccount</returns>
    SubaccountInfo AddSubaccount(SubaccountInfo subaccount, string notes = "");

    /// <summary>
    ///     Asynchronously add a new subaccount.
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=add">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="subaccount">The subaccount to add</param>
    /// <param name="notes">Optional extra text to associate with the subaccount</param>
    /// <returns>the information saved about the new subaccount</returns>
    Task<SubaccountInfo> AddSubaccountAsync(SubaccountInfo subaccount, string notes);

    /// <summary>
    ///     Delete an existing subaccount. Any email related to the subaccount will be saved, but stats will be removed and any
    ///     future sending calls to this subaccount will fail.
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=delete">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="id">The unique identifier of the subaccount to delete</param>
    /// <returns>the information for the deleted subaccount</returns>
    SubaccountInfo DeleteSubaccount(string id);

    /// <summary>
    ///     Asynchronously delete an existing subaccount. Any email related to the subaccount will be saved, but stats will be
    ///     removed and any future sending calls to this subaccount will fail.
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=delete">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="id">The unique identifier of the subaccount to delete</param>
    /// <returns>the information for the deleted subaccount</returns>
    Task<SubaccountInfo> DeleteSubaccountAsync(string id);

    /// <summary>
    ///     Get the list of subaccounts defined for the account, optionally filtered by a prefix.
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=list">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="q">An optional prefix to filter the subaccounts' ids and names</param>
    /// <returns>the subaccounts for the account, up to a maximum of 1,000</returns>
    List<SubaccountInfo> ListSubaccounts(string q = "");

    /// <summary>
    ///     Asynchronously get the list of subaccounts defined for the account, optionally filtered by a prefix.
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=list">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="q">An optional prefix to filter the subaccounts' ids and names.</param>
    /// <returns>the subaccounts for the account, up to a maximum of 1,000</returns>
    Task<List<SubaccountInfo>> ListSubaccountsAsync(string q = "");

    /// <summary>
    ///     Pause a subaccount's sending. Any future emails delivered to this subaccount will be queued for a maximum of 3 days
    ///     until the subaccount is resumed.
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=pause">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="id">The unique identifier of the subaccount to pause</param>
    /// <returns>the information for the paused subaccount</returns>
    SubaccountInfo PauseSubaccount(string id);

    /// <summary>
    ///     Asynchronously pause a subaccount's sending. Any future emails delivered to this subaccount will be queued for a
    ///     maximum of 3 days until the subaccount is resumed.
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=pause">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="id">The unique identifier of the subaccount to pause</param>
    /// <returns>the information for the paused subaccount</returns>
    Task<SubaccountInfo> PauseSubaccountAsync(string id);

    /// <summary>
    ///     Resume a paused subaccount's sending
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=resume">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="id">The unique identifier of the subaccount to resume</param>
    /// <returns>the information for the resumed subaccount</returns>
    SubaccountInfo ResumeSubaccount(string id);

    /// <summary>
    ///     Asynchronously resume a paused subaccount's sending
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=resume">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="id">The unique identifier of the subaccount to resume</param>
    /// <returns>the information for the resumed subaccount</returns>
    Task<SubaccountInfo> ResumeSubaccountAsync(string id);

    /// <summary>
    ///     Given the ID of an existing subaccount, return the data about it
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=info">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="id">The unique identifier of the subaccount to query</param>
    /// <returns>the information about the subaccount</returns>
    SubaccountInfo SubaccountInfo(string id);

    /// <summary>
    ///     Given the ID of an existing subaccount, asynchronously return the data about it
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=info">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="id">The unique identifier of the subaccount to query</param>
    /// <returns>the information about the subaccount</returns>
    Task<SubaccountInfo> SubaccountInfoAsync(string id);

    /// <summary>
    ///     Update an existing subaccount
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=update">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="subaccount">The subaccount to update</param>
    /// <param name="notes">Optional extra text to associate with the subaccount</param>
    /// <returns>the information for the updated subaccount</returns>
    SubaccountInfo UpdateSubaccount(SubaccountInfo subaccount, string notes = "");

    /// <summary>
    ///     Asynchronously update an existing subaccount
    ///     <see cref="https://mandrillapp.com/api/docs/subaccounts.JSON.html#method=update">Mandrill API Documentation</see>
    /// </summary>
    /// <param name="subaccount">The subaccount to update</param>
    /// <param name="notes">Optional extra text to associate with the subaccount</param>
    /// <returns>the information for the updated subaccount</returns>
    Task<SubaccountInfo> UpdateSubaccountAsync(SubaccountInfo subaccount, string notes = "");

    /// <summary>
    ///     Validate an API key and respond to a ping
    /// </summary>
    /// <returns>
    ///     The <see cref="string" />.
    /// </returns>
    Task<string> Ping();


    /// <summary>
    ///     Return the information about the API-connected user
    /// </summary>
    /// <returns>
    ///     The <see cref="Task" />.
    /// </returns>
    /// <see cref="https://mandrillapp.com/api/docs/users.html#method=info" />
    Task<UserInfo> UserInfo();


    /// <summary>
    /// Adds the reject.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>Task&lt;RejectAddResult&gt;.</returns>
    Task<RejectAddResult> AddReject(AddRejectRequest request);

    /// <summary>
    ///     The delete reject.
    /// </summary>
    /// <param name="email">
    ///     The email.
    /// </param>
    /// <returns>
    ///     The <see cref="RejectDeleteResult" />.
    /// </returns>
    /// <exception cref="Exception">
    /// </exception>
    RejectDeleteResult DeleteReject(string email);

    /// <summary>
    ///     The delete reject async.
    /// </summary>
    /// <param name="email">
    ///     The email.
    /// </param>
    /// <returns>
    ///     The <see cref="Task" />.
    /// </returns>
    Task<RejectDeleteResult> DeleteRejectAsync(string email);

    /// <summary>
    /// </summary>
    /// <param name="email">
    ///     email address to limit the results
    /// </param>
    /// <returns>
    ///     The <see cref="List{T}" />.
    /// </returns>
    List<RejectInfo> ListRejects(string email = "");

    /// <summary>
    /// </summary>
    /// <param name="email">
    ///     email address to limit the results
    /// </param>
    /// <returns>
    ///     The <see cref="Task" />.
    /// </returns>
    Task<List<RejectInfo>> ListRejectsAsync(string email = "");
  }
}