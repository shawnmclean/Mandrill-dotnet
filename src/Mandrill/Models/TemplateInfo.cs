// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemplateInfo.cs" company="">
//   
// </copyright>
// <summary>
//   The template info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill.Models
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    ///     The template info.
    /// </summary>
    public class TemplateInfo
    {
        #region Public Properties

        /// <summary>
        ///     The date and time the template was first created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime Created { get; set; }

        /// <summary>
        ///     The default sender address for the template, if provided.
        /// </summary>
        [JsonProperty("from_email")]
        public string FromEmail { get; set; }

        /// <summary>
        ///     The default sender from name for the template, if provided.
        /// </summary>
        [JsonProperty("from_name")]
        public string FromName { get; set; }

        /// <summary>
        ///     The list of labels applied to the template.
        /// </summary>
        [JsonProperty("labels")]
        public IEnumerable<string> Labels { get; set; }

        /// <summary>
        ///     The default sender address for the template, if provided.
        /// </summary>
        [JsonProperty("publish_from_email")]
        public string PublishFromEmail { get; set; }

        /// <summary>
        ///     The default sender from name for the template, if provided.
        /// </summary>
        [JsonProperty("publish_from_name")]
        public string PublishFromName { get; set; }

        /// <summary>
        ///     The subject line of the template, if provided.
        /// </summary>
        [JsonProperty("publish_subject")]
        public string PublishSubject { get; set; }

        /// <summary>
        ///     The default text part of messages sent with the template, if
        ///     provided.
        /// </summary>
        [JsonProperty("publish_text")]
        public string PublishText { get; set; }

        /// <summary>
        ///     The date and time the template was last published, or null if it
        ///     has not been published.
        /// </summary>
        [JsonProperty("published_at")]
        public DateTime Published { get; set; }

        /// <summary>
        ///     The immutable unique code name of the template.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        ///     The subject line of the template, if provided.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        ///     The default text part of messages sent with the template, if provided.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        ///     The date and time the template was last modified.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime Updated { get; set; }

        /// <summary>
        ///     The full HTML code of the template, with <c>mc:edit</c> attributes
        ///     marking the editable elements.
        /// </summary>
        [JsonProperty("code")]
        public string code { get; set; }

        /// <summary>
        ///     The name of the template.
        /// </summary>
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        ///     The full HTML code of the template, with <c>mc:edit</c> attributes
        ///     marking the editable elements that are available as published, if
        ///     it has been published.
        /// </summary>
        [JsonProperty("publish_code")]
        public string publish_code { get; set; }

        /// <summary>
        ///     The same as the template name - kept as a separate field for
        ///     backwards compatibility.
        /// </summary>
        /// <seealso cref="Name" />
        [JsonProperty("publish_name")]
        public string publish_name { get; set; }

        #endregion
    }
}