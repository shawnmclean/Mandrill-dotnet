using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mandrill.Requests.Templates
{
  /// <summary>
  ///   Class UpdateTemplateRequest.
  /// </summary>
  public class UpdateTemplateRequest : RequestBase
  {
    public UpdateTemplateRequest(string name)
    {
      Name = name;
    }

    /// <summary>
    ///   Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///   Gets or sets the from_email.
    /// </summary>
    /// <value>The from_email.</value>
    [JsonPropertyName("from_email")]
    public string FromEmail { get; set; }

    /// <summary>
    ///   Gets or sets the from_name.
    /// </summary>
    /// <value>The from_name.</value>
    [JsonPropertyName("from_name")]
    public string FromName { get; set; }

    /// <summary>
    ///   Gets or sets the subject.
    /// </summary>
    /// <value>The subject.</value>
    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    /// <summary>
    ///   Gets or sets the code.
    /// </summary>
    /// <value>The code.</value>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    ///   Gets or sets the text.
    /// </summary>
    /// <value>The text.</value>
    [JsonPropertyName("text")]
    public string Text { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether this <see cref="UpdateTemplateRequest" /> is publish.
    /// </summary>
    /// <value><c>true</c> if publish; otherwise, <c>false</c>.</value>
    [JsonPropertyName("publish")]
    public bool Publish { get; set; }

    /// <summary>
    ///   Gets or sets the labels.
    /// </summary>
    /// <value>The labels.</value>
    [JsonPropertyName("labels")]
    public IEnumerable<string> Labels { get; set; }
  }
}