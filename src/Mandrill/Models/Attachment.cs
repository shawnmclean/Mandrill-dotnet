namespace Mandrill
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Information about an individual attachment.
    /// </summary>
    public class Attachment
    {
        #region Public Properties

        /// <summary>
        ///     Content of the attachment as a base64 encoded string.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        ///     File name of the attachment.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     MIME type of the attachment.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        #endregion
    }
}