using System;
using Mandrill.Models;
using Newtonsoft.Json;

namespace Mandrill.Requests.Messages
{
  /// <summary>
  ///   Class SendMessageRequest.
  /// </summary>
  public class SendMessageRequest : RequestBase
  {
    public SendMessageRequest(EmailMessage message)
    {
      Message = message;
    }

    /// <summary>
    ///   Gets or sets the message.
    /// </summary>
    /// <value>The message.</value>
    [JsonProperty("message")]
    public EmailMessage Message { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether this <see cref="SendMessageRequest" /> is asynchronous.
    /// </summary>
    /// <value><c>true</c> if asynchronous; otherwise, <c>false</c>.</value>
    [JsonProperty("async")]
    public bool Async { get; set; }

    /// <summary>
    ///   Gets or sets the ip pool.
    /// </summary>
    /// <value>The ip pool.</value>
    [JsonProperty("ip_pool")]
    public string IpPool { get; set; }

    /// <summary>
    ///   Gets or sets the send at.
    /// </summary>
    /// <value>The send at.</value>
    [JsonProperty("send_at")]
    public DateTime? SendAt { get; set; }
  }
}