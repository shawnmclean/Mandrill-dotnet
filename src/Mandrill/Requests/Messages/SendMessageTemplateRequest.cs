using System;
using System.Collections.Generic;
using Mandrill.Models;
using Newtonsoft.Json;

namespace Mandrill.Requests.Messages
{
  /// <summary>
  /// The request to send a new transactional message through Mandrill using a template.
  /// </summary>
  public class SendMessageTemplateRequest : RequestBase
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message">The other information on the message to send - same as /messages/send, but without the html content.</param>
    /// <param name="templateName">The immutable name or slug of a template that exists in the user's account. For backwards-compatibility, the template name may also be used but the immutable slug is preferred.</param>
    public SendMessageTemplateRequest(EmailMessage message, string templateName)
    {
      Message = message;
      TemplateName = templateName;
      TemplateContents = new TemplateContent[] {};
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message">The other information on the message to send - same as /messages/send, but without the html content.</param>
    /// <param name="templateName">The immutable name or slug of a template that exists in the user's account. For backwards-compatibility, the template name may also be used but the immutable slug is preferred.</param>
    /// <param name="templateContents">An array of template content to send.</param>
    public SendMessageTemplateRequest(EmailMessage message, string templateName, IEnumerable<TemplateContent> templateContents)
    {
      Message = message;
      TemplateName = templateName;
      TemplateContents = templateContents;
    }

    /// <summary>
    /// The other information on the message to send - same as /messages/send, but without the html content.
    /// </summary>
    [JsonProperty("message")]
    public EmailMessage Message { get; set; }

    /// <summary>
    /// The immutable name or slug of a template that exists in the user's account. For backwards-compatibility, the template name may also be used but the immutable slug is preferred.
    /// </summary>
    [JsonProperty("template_name")]
    public string TemplateName { get; set; }

    /// <summary>
    /// An array of template content to send.
    /// </summary>
    [JsonProperty("template_content")]
    public IEnumerable<TemplateContent> TemplateContents { get; set; }

    /// <summary>
    /// Enable a background sending mode that is optimized for bulk sending. In async mode, messages/send will immediately return a status of "queued" for every recipient. 
    /// To handle rejections when sending in async mode, set up a webhook for the 'reject' event. Defaults to false for messages with no more than 10 recipients; 
    /// messages with more than 10 recipients are always sent asynchronously, regardless of the value of async.
    /// </summary>
    [JsonProperty("async")]
    public bool Async { get; set; }

    /// <summary>
    /// The name of the dedicated ip pool that should be used to send the message. If you do not have any dedicated IPs, this parameter has no effect. If you specify a pool that does not exist, your default pool will be used instead.
    /// </summary>
    [JsonProperty("ip_pool")]
    public string IpPool { get; set; }

    /// <summary>
    /// When this message should be sent as a UTC timestamp in YYYY-MM-DD HH:MM:SS format. 
    /// If you specify a time in the past, the message will be sent immediately. 
    /// An additional fee applies for scheduled email, and this feature is only available to accounts with a positive balance.
    /// </summary>
    [JsonProperty("send_at")]
    public DateTime? SendAt { get; set; }
  }
}