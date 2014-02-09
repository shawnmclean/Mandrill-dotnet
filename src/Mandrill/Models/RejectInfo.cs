// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RejectInfo.cs" company="">
//   
// </copyright>
// <summary>
//   The reject info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    using Newtonsoft.Json;

    /// <summary>
    ///     The reject info.
    /// </summary>
    public class RejectInfo
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the created at.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether expired.
        /// </summary>
        [JsonProperty("expired")]
        public bool Expired { get; set; }

        /// <summary>
        ///     Gets or sets the expires at.
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; }

        /// <summary>
        ///     Gets or sets the reason.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        #endregion

        // TODO: Add property: Sender: "Sender":{"...": "..."}
    }

    /// <summary>
    ///     The reject delete result.
    /// </summary>
    public class RejectDeleteResult
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets a value indicating whether deleted.
        /// </summary>
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        #endregion
    }
}