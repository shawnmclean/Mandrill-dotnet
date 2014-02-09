namespace Mandrill
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Message recipient's information.
    /// </summary>
    public class Recipient
    {
        #region Public Properties

        /// <summary>
        ///     Email address of the recipient.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Alias of the recipient (if any).
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        #endregion
    }
}