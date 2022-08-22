using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mandrill.Requests.Messages
{
  /// <summary>
  ///   Class SendRawMessageRequest.
  /// </summary>
  public class SendRawMessageRequest : RequestBase
  {
    public SendRawMessageRequest(string rawMessage)
    {
      RawMessage = rawMessage;
    }

    /// <summary>
    ///   Gets or sets the raw message.
    /// </summary>
    /// <value>The raw message.</value>
    [JsonPropertyName("raw_message")]
    public string RawMessage { get; set; }

    /// <summary>
    ///   Gets or sets from email.
    /// </summary>
    /// <value>From email.</value>
    [JsonPropertyName("from_email")]
    public string FromEmail { get; set; }

    /// <summary>
    ///   Gets or sets from name.
    /// </summary>
    /// <value>From name.</value>
    [JsonPropertyName("from_name")]
    public string FromName { get; set; }

    /// <summary>
    ///   Gets or sets to emails.
    /// </summary>
    /// <value>To emails.</value>
    [JsonPropertyName("to")]
    public List<string> ToEmails { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether this <see cref="SendRawMessageRequest" /> is asynchronous.
    /// </summary>
    /// <value><c>true</c> if asynchronous; otherwise, <c>false</c>.</value>
    [JsonPropertyName("async")]
    public bool Async { get; set; }

    /// <summary>
    ///   Gets or sets the ip pool.
    /// </summary>
    /// <value>The ip pool.</value>
    [JsonPropertyName("ip_pool")]
    public string IpPool { get; set; }

    /// <summary>
    ///   Gets or sets the send at.
    /// </summary>
    /// <value>The send at.</value>
    [JsonPropertyName("send_at")]
    public DateTime? SendAt { get; set; }

    /// <summary>
    ///   Gets or sets the return path domain.
    /// </summary>
    /// <value>The return path domain.</value>
    [JsonPropertyName("return_path_domain")]
    public string ReturnPathDomain { get; set; }
  }
}