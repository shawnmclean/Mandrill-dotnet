using Newtonsoft.Json;

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
    public string Content { get; set; }

    /// <summary>
    ///   File name of the attachment.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///   MIME type of the attachment.
    /// </summary>
    public string Type { get; set; }

    #endregion
  }
}