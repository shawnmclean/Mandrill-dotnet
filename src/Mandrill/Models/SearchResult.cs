// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchResult.cs" company="">
//   
// </copyright>
// <summary>
//   The search result state.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    ///     The search result state.
    /// </summary>
    public enum SearchResultState
    {
        /// <summary>
        ///     The sent.
        /// </summary>
        Sent,

        /// <summary>
        ///     The bounced.
        /// </summary>
        Bounced,

        /// <summary>
        ///     The rejected.
        /// </summary>
        Rejected,

        /// <summary>
        ///     The soft bounced.
        /// </summary>
        [EnumMember(Value = "soft-bounced")]
        SoftBounced,

        /// <summary>
        ///     The spam.
        /// </summary>
        Spam,

        /// <summary>
        ///     The unsub.
        /// </summary>
        Unsub,

        /// <summary>
        ///     The deferred.
        /// </summary>
        Deferred
    }

    /// <summary>
    ///     The search result.
    /// </summary>
    public class SearchResult
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the _id.
        /// </summary>
        public string _id { get; set; }

        /// <summary>
        ///     Gets or sets the bounce_description.
        /// </summary>
        public string bounce_description { get; set; }

        /// <summary>
        ///     Gets or sets the clicks.
        /// </summary>
        public int clicks { get; set; }

        /// <summary>
        ///     Gets or sets the diag.
        /// </summary>
        public string diag { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        ///     Gets or sets the metadata.
        /// </summary>
        public Dictionary<string, string> metadata { get; set; }

        /// <summary>
        ///     Gets or sets the opens.
        /// </summary>
        public int opens { get; set; }

        /// <summary>
        ///     Gets or sets the sender.
        /// </summary>
        public string sender { get; set; }

        /// <summary>
        ///     Gets or sets the smtp_events.
        /// </summary>
        public IEnumerable<SmtpEvent> smtp_events { get; set; }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SearchResultState state { get; set; }

        /// <summary>
        ///     Gets or sets the subject.
        /// </summary>
        public string subject { get; set; }

        /// <summary>
        ///     Gets or sets the tags.
        /// </summary>
        public string[] tags { get; set; }

        /// <summary>
        ///     Gets or sets the ts.
        /// </summary>
        public int ts { get; set; }

        #endregion
    }
}