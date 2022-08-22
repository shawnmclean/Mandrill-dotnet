using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  /// <summary>
  ///   Content of the message.
  /// </summary>
  public class Content
  {
    #region Public Properties

    /// <summary>
    ///   Array of any attachments that can be found in the message.
    /// </summary>
    [JsonPropertyName("attachments")]
    public IList<Attachment> Attachments { get; set; }

    /// <summary>
    ///   Email address of the sender.
    /// </summary>
    [JsonPropertyName("from_email")]
    public string FromEmail { get; set; }

    /// <summary>
    ///   Alias of the sender (if any).
    /// </summary>
    [JsonPropertyName("from_name")]
    public string FromName { get; set; }

    /// <summary>
    ///   Key-value pairs of the custom MIME headers for the message's main
    ///   document.
    /// </summary>
    [JsonPropertyName("headers")]
    public IDictionary<string, string> Headers { get; set; }

    /// <summary>
    ///   HTML part of the message.
    /// </summary>
    [JsonPropertyName("html")]
    public string Html { get; set; }

    /// <summary>
    ///   Message's unique id.
    /// </summary>
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    /// <summary>
    ///   Message's subject line.
    /// </summary>
    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    /// <summary>
    ///   List of tags on this message.
    /// </summary>
    [JsonPropertyName("tags")]
    public string[] Tags { get; set; }

    /// <summary>
    ///   Text part of the message.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; }

    /// <summary>
    ///   Unix timestamp from when this message was sent.
    /// </summary>
    [JsonPropertyName("ts")]
    public long Timestamp { get; set; }

    /// <summary>
    ///   Message recipient's information.
    /// </summary>
    [JsonPropertyName("to")]
    public Recipient To { get; set; }

    #endregion
  }
}