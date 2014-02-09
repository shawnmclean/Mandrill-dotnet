// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailResult.cs" company="">
//   
// </copyright>
// <summary>
//   The email result status.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    ///     The email result status.
    /// </summary>
    public enum EmailResultStatus
    {
        /// <summary>
        ///     The sent.
        /// </summary>
        Sent,

        /// <summary>
        ///     The queued.
        /// </summary>
        Queued,

        /// <summary>
        ///     The rejected.
        /// </summary>
        Rejected,

        /// <summary>
        ///     The invalid.
        /// </summary>
        Invalid,

        /// <summary>
        ///     The scheduled.
        /// </summary>
        Scheduled
    }

    /// <summary>
    ///     The email result.
    /// </summary>
    public class EmailResult
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        ///     Reason for reject
        /// </summary>
        [JsonProperty("reject_reason")]
        public string RejectReason { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EmailResultStatus Status { get; set; }

        #endregion
    }
}