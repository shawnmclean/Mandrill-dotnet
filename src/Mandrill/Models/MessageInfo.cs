using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  /// <summary>
  ///   The information of a recently sent message
  /// </summary>
  public class MessageInfo
  {
    /// <summary>
    ///   Gets or sets the time stamp.
    /// </summary>
    /// <value>The time stamp.</value>
    [JsonPropertyName("ts")]
    public long TimeStamp { get; set; }

    /// <summary>
    ///   Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    /// <summary>
    ///   Gets or sets the sender.
    /// </summary>
    /// <value>The sender.</value>
    [JsonPropertyName("sender")]
    public string Sender { get; set; }

    /// <summary>
    ///   Gets or sets the template.
    /// </summary>
    /// <value>The template.</value>
    [JsonPropertyName("template")]
    public string Template { get; set; }

    /// <summary>
    ///   Gets or sets the subject.
    /// </summary>
    /// <value>The subject.</value>
    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    /// <summary>
    ///   Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    ///   Gets or sets the click details.
    /// </summary>
    /// <value>The click details.</value>
    [JsonPropertyName("clicks_detail")]
    public IEnumerable<ClickDetail> ClickDetails { get; set; }

    /// <summary>
    ///   Gets or sets the opens.
    /// </summary>
    /// <value>The opens.</value>
    [JsonPropertyName("opens")]
    public string Opens { get; set; }

    /// <summary>
    ///   Gets or sets the clicks.
    /// </summary>
    /// <value>The clicks.</value>
    [JsonPropertyName("clicks")]
    public string Clicks { get; set; }

    /// <summary>
    ///   Gets or sets the open details.
    /// </summary>
    /// <value>The open details.</value>
    [JsonPropertyName("opens_detail")]
    public IEnumerable<OpenDetail> OpenDetails { get; set; }

    /// <summary>
    ///   Gets or sets the state.
    /// </summary>
    /// <value>The state.</value>
    [JsonPropertyName("state")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public SearchResultState State { get; set; }

    /// <summary>
    ///   Gets or sets the meta data.
    /// </summary>
    /// <value>The meta data.</value>
    [JsonPropertyName("metadata")]
    public MessageInfoMetaData MetaData { get; set; }
  }

  /// <summary>
  ///   Class MessageInfoMetaData.
  /// </summary>
  public class MessageInfoMetaData
  {
    /// <summary>
    ///   Gets or sets the user identifier.
    /// </summary>
    /// <value>The user identifier.</value>
    [JsonPropertyName("user_id")]
    public string UserId { get; set; }

    /// <summary>
    ///   Gets or sets the website.
    /// </summary>
    /// <value>The website.</value>
    [JsonPropertyName("website")]
    public string Website { get; set; }
  }

  /// <summary>
  ///   Class OpenDetail.
  /// </summary>
  public class OpenDetail
  {
    /// <summary>
    ///   Gets or sets the time stamp.
    /// </summary>
    /// <value>The time stamp.</value>
    [JsonPropertyName("ts")]
    public long TimeStamp { get; set; }

    /// <summary>
    ///   Gets or sets the ip.
    /// </summary>
    /// <value>The ip.</value>
    [JsonPropertyName("ip")]
    public string Ip { get; set; }

    /// <summary>
    ///   Gets or sets the location.
    /// </summary>
    /// <value>The location.</value>
    [JsonPropertyName("location")]
    public string Location { get; set; }

    /// <summary>
    ///   Gets or sets the user agent.
    /// </summary>
    /// <value>The user agent.</value>
    [JsonPropertyName("ua")]
    public string UserAgent { get; set; }
  }

  /// <summary>
  ///   Class ClickDetail.
  /// </summary>
  public class ClickDetail : OpenDetail
  {
    /// <summary>
    ///   Gets or sets the URL.
    /// </summary>
    /// <value>The URL.</value>
    [JsonPropertyName("url")]
    public string Url { get; set; }
  }
}