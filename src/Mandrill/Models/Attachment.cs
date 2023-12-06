using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  /// <summary>
  ///   Information about an individual attachment.
  /// </summary>
  public class Attachment
  {
    #region Public Properties

    /// <summary>
    ///   Content of the attachment as a base64 encoded string.
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; set; }

    /// <summary>
    ///   File name of the attachment.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///   MIME type of the attachment.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    #endregion
  }
}