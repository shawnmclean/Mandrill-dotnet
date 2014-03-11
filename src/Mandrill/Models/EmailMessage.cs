// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailMessage.cs" company="">
//   
// </copyright>
// <summary>
//   The merge_var.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    using System.Collections.Generic;
    using System.Linq;

    using RestSharp;

    /// <summary>
    ///     The merge_var.
    /// </summary>
    public struct merge_var
    {
        #region Fields

        /// <summary>
        ///     The content.
        /// </summary>
        public string content;

        /// <summary>
        ///     The name.
        /// </summary>
        public string name;

        #endregion
    }

    /// <summary>
    ///     The rcpt_merge_var.
    /// </summary>
    public class rcpt_merge_var
    {
        #region Fields

        /// <summary>
        ///     The rcpt.
        /// </summary>
        public string rcpt;

        /// <summary>
        ///     The vars.
        /// </summary>
        public List<merge_var> vars;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="rcpt_merge_var" /> class.
        /// </summary>
        public rcpt_merge_var()
        {
            this.vars = new List<merge_var>();
        }

        #endregion
    }

    /// <summary>
    ///     The rcpt_metadata.
    /// </summary>
    public struct rcpt_metadata
    {
        #region Fields

        /// <summary>
        ///     The rcpt.
        /// </summary>
        public string rcpt;

        /// <summary>
        ///     The values.
        /// </summary>
        public JsonObject values;

        #endregion
    }

    /// <summary>
    ///     The attachment.
    /// </summary>
    public struct attachment
    {
        #region Fields

        /// <summary>
        ///     The content.
        /// </summary>
        public string content;

        /// <summary>
        ///     The name.
        /// </summary>
        public string name;

        /// <summary>
        ///     The type.
        /// </summary>
        public string type;

        #endregion
    }

    /// <summary>
    ///     The image.
    /// </summary>
    public struct image
    {
        #region Fields

        /// <summary>
        ///     The content.
        /// </summary>
        public string content;

        /// <summary>
        ///     The name.
        /// </summary>
        public string name;

        /// <summary>
        ///     The type.
        /// </summary>
        public string type;

        #endregion
    }

    /// <summary>
    ///     The email message.
    /// </summary>
    public class EmailMessage
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the attachments.
        /// </summary>
        public IEnumerable<attachment> attachments { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether auto_text.
        /// </summary>
        public bool auto_text { get; set; }

        /// <summary>
        ///     Gets or sets the bcc_address.
        /// </summary>
        public string bcc_address { get; set; }

        /// <summary>
        ///     Gets or sets the from_email.
        /// </summary>
        public string from_email { get; set; }

        /// <summary>
        ///     Gets or sets the from_name.
        /// </summary>
        public string from_name { get; set; }

        /// <summary>
        ///     Gets the global_merge_vars.
        /// </summary>
        public List<merge_var> global_merge_vars { get; private set; }

        /// <summary>
        ///     Gets or sets the google_analytics_campaign.
        /// </summary>
        public string google_analytics_campaign { get; set; }

        /// <summary>
        ///     Gets or sets the google_analytics_domains.
        /// </summary>
        public IEnumerable<string> google_analytics_domains { get; set; }

        /// <summary>
        ///     Gets the headers.
        /// </summary>
        public JsonObject headers { get; private set; }

        /// <summary>
        ///     Gets or sets the html.
        /// </summary>
        public string html { get; set; }

        /// <summary>
        ///     Gets or sets the images.
        /// </summary>
        public IEnumerable<image> images { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether important.
        /// </summary>
        public bool important { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether merge.
        /// </summary>
        public bool merge { get; set; }

        /// <summary>
        ///     Gets the merge_vars.
        /// </summary>
        public List<rcpt_merge_var> merge_vars { get; private set; }

        /// <summary>
        ///     Gets the metadata.
        /// </summary>
        public JsonObject metadata { get; private set; }

        /// <summary>
        ///     Gets or sets a value indicating whether preserve_recipients.
        /// </summary>
        public bool preserve_recipients { get; set; }

        /// <summary>
        ///     Gets or sets the raw_message.
        /// </summary>
        public string raw_message { get; set; }

        /// <summary>
        ///     Gets or sets the recipient_metadata.
        /// </summary>
        public IEnumerable<rcpt_metadata> recipient_metadata { get; set; }

        /// <summary>
        ///     Gets or sets the signing_domain.
        /// </summary>
        /// <remarks>
        ///     a custom domain to use for SPF/DKIM signing instead of mandrill (for "via" or "on behalf of" in email clients)
        /// </remarks>
        /// <value>
        ///     The signing_domain.
        /// </value>
        public string signing_domain { get; set; }

        /// <summary>
        ///     Gets or sets the subaccount.
        /// </summary>
        public string subaccount { get; set; }

        /// <summary>
        ///     Gets or sets the subject.
        /// </summary>
        public string subject { get; set; }

        /// <summary>
        ///     Gets or sets the tags.
        /// </summary>
        public IEnumerable<string> tags { get; set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        public string text { get; set; }

        /// <summary>
        ///     Gets or sets the to.
        /// </summary>
        public IEnumerable<EmailAddress> to { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether track_clicks.
        /// </summary>
        public bool track_clicks { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether track_opens.
        /// </summary>
        public bool track_opens { get; set; }

        /// <summary>
        ///     Gets or sets the tracking_domain.
        /// </summary>
        /// <remarks>
        ///     a custom domain to use for tracking opens and clicks instead of mandrillapp.com
        /// </remarks>
        /// <value>
        ///     The tracking_domain.
        /// </value>
        public string tracking_domain { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether url_strip_qs.
        /// </summary>
        public bool url_strip_qs { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether inline_css.
        /// </summary>
        public bool inline_css { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The add global variable.
        /// </summary>
        /// <param name="name">
        ///     The name.
        /// </param>
        /// <param name="content">
        ///     The content.
        /// </param>
        public void AddGlobalVariable(string name, string content)
        {
            if (this.global_merge_vars == null)
            {
                this.global_merge_vars = new List<merge_var>();
            }

            var mv = new merge_var { name = name, content = content };
            this.global_merge_vars.Add(mv);
        }

        /// <summary>
        ///     The add header.
        /// </summary>
        /// <param name="name">
        ///     The name.
        /// </param>
        /// <param name="value">
        ///     The value.
        /// </param>
        public void AddHeader(string name, string value)
        {
            if (this.headers == null)
            {
                this.headers = new JsonObject();
            }

            this.headers[name] = value;
        }

        /// <summary>
        ///     The add metadata.
        /// </summary>
        /// <param name="key">
        ///     The key.
        /// </param>
        /// <param name="value">
        ///     The value.
        /// </param>
        public void AddMetadata(string key, string value)
        {
            if (this.metadata == null)
            {
                this.metadata = new JsonObject();
            }

            this.metadata[key] = value;
        }

        /// <summary>
        ///     The add recipient variable.
        /// </summary>
        /// <param name="recipient">
        ///     The recipient.
        /// </param>
        /// <param name="name">
        ///     The name.
        /// </param>
        /// <param name="content">
        ///     The content.
        /// </param>
        public void AddRecipientVariable(string recipient, string name, string content)
        {
            if (this.merge_vars == null)
            {
                this.merge_vars = new List<rcpt_merge_var>();
            }

            rcpt_merge_var entry = this.merge_vars.Where(e => e.rcpt == recipient).FirstOrDefault();
            if (entry == null)
            {
                entry = new rcpt_merge_var { rcpt = recipient };
                this.merge_vars.Add(entry);
            }

            var mv = new merge_var { name = name, content = content };

            entry.vars.Add(mv);
        }

        #endregion
    }
}