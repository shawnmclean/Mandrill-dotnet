// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduledEmailResult.cs" company="">
//   
// </copyright>
// <summary>
//   The scheduled email result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    ///     The scheduled email result.
    /// </summary>
    public class ScheduledEmailResult
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the created at.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Gets or sets the from email.
        /// </summary>
        [JsonProperty("from_email")]
        public string FromEmail { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the send at.
        /// </summary>
        [JsonProperty("send_at")]
        public DateTime SendAt { get; set; }

        /// <summary>
        ///     Gets or sets the subject.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        ///     Gets or sets the to email.
        /// </summary>
        [JsonProperty("to")]
        public string ToEmail { get; set; }

        #endregion
    }
}