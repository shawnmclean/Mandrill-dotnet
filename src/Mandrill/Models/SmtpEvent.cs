// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmtpEvent.cs" company="">
//   
// </copyright>
// <summary>
//   The smtp event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    ///     The smtp event.
    /// </summary>
    public class SmtpEvent
    {
        #region Public Properties

        /// <summary>
        ///     Gets the time stamp.
        /// </summary>
        public DateTime TimeStamp
        {
            get
            {
                return WebHookEvent.FromUnixTime(this.ts);
            }
        }

        /// <summary>
        ///     Gets or sets the destination_ip.
        /// </summary>
        public string destination_ip { get; set; }

        /// <summary>
        ///     Gets or sets the diag.
        /// </summary>
        public string diag { get; set; }

        /// <summary>
        ///     Gets or sets the size.
        /// </summary>
        public int size { get; set; }

        /// <summary>
        ///     Gets or sets the source_ip.
        /// </summary>
        public string source_ip { get; set; }

        /// <summary>
        ///     Gets or sets the ts.
        /// </summary>
        public int ts { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SearchResultState type { get; set; }

        #endregion
    }
}