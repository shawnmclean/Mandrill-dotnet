// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailMessage.cs" company="">
//   
// </copyright>
// <summary>
//   The merge_var.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace Mandrill.Models
{
  /// <summary>
  ///   Defines the template syntax.
  /// </summary>
  public static class TemplateSyntax
  {
    /// <summary>
    ///   Uses the MailChimp template syntax.
    /// </summary>
    public const string Mailchimp = "mailchimp";

    /// <summary>
    ///   Uses the handlebars template syntax.
    /// </summary>
    public const string Handlebars = "handlebars";
  }

  /// <summary>
  ///   The merge_var.
  /// </summary>
  public class MergeVar
  {
    #region Fields

    /// <summary>
    ///   The content.
    /// </summary>
    [JsonProperty("content")]
    public string Content { get; set; }

    /// <summary>
    ///   The name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    #endregion
  }

  /// <summary>
  ///   The rcpt_merge_var.
  /// </summary>
  public class RcptMergeVar
  {
    #region Fields

    /// <summary>
    ///   The rcpt.
    /// </summary>
    [JsonProperty("rcpt")]
    public string Rcpt { get; set; }

    /// <summary>
    ///   The vars.
    /// </summary>
    [JsonProperty("vars")]
    public List<MergeVar> Vars { get; set; }

    #endregion

    #region Constructors and Destructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="RcptMergeVar" /> class.
    /// </summary>
    public RcptMergeVar()
    {
      Vars = new List<MergeVar>();
    }

    #endregion
  }

  /// <summary>
  ///   The rcpt_metadata.
  /// </summary>
  public class RcptMetadata
  {
    #region Fields

    /// <summary>
    ///   The rcpt.
    /// </summary>
    [JsonProperty("rcpt")]
    public string Rcpt { get; set; }

    /// <summary>
    ///   The values.
    /// </summary>
    [JsonProperty("values")]
    public JsonObject Values { get; set; }

    #endregion
  }

  /// <summary>
  ///   The attachment.
  /// </summary>
  public class EmailAttachment
  {
    #region Fields

    /// <summary>
    ///   The content.
    /// </summary>
    [JsonProperty("content")]
    public string Content { get; set; }

    /// <summary>
    ///   The name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    ///   The type.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }

    /// <summary>
    ///   True if the attachment is base64 encoded
    /// </summary>
    [JsonProperty("base64")]
    public bool Base64 { get; set; }

    #endregion
  }

  /// <summary>
  ///   The image.
  /// </summary>
  public class Image
  {
    #region Fields

    /// <summary>
    ///   The content.
    /// </summary>
    [JsonProperty("content")]
    public string Content { get; set; }

    /// <summary>
    ///   The name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    ///   The type.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }

    #endregion
  }

  /// <summary>
  ///   The email message.
  /// </summary>
  public class EmailMessage
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the attachments.
    /// </summary>
    [JsonProperty("attachments")]
    public IEnumerable<EmailAttachment> Attachments { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether auto_html.
    /// </summary>
    [JsonProperty("auto_html")]
    public bool? AutoHtml { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether auto_text.
    /// </summary>
    [JsonProperty("auto_text")]
    public bool? AutoText { get; set; }

    /// <summary>
    ///   Gets or sets the bcc_address.
    /// </summary>
    [JsonProperty("bcc_address")]
    public string BccAddress { get; set; }

    /// <summary>
    ///   Gets or sets the from_email.
    /// </summary>
    [JsonProperty("from_email")]
    public string FromEmail { get; set; }

    /// <summary>
    ///   Gets or sets the from_name.
    /// </summary>
    [JsonProperty("from_name")]
    public string FromName { get; set; }

    /// <summary>
    ///   Gets the global_merge_vars.
    /// </summary>
    [JsonProperty("global_merge_vars")]
    public List<MergeVar> GlobalMergeVars { get; private set; }

    /// <summary>
    ///   Gets or sets the google_analytics_campaign.
    ///   TODO the api docs state that this can be a string or an array
    /// </summary>
    [JsonProperty("google_analytics_campaign")]
    public string GoogleAnalyticsCampaign { get; set; }

    /// <summary>
    ///   Gets or sets the google_analytics_domains.
    /// </summary>
    [JsonProperty("google_analytics_domains")]
    public IEnumerable<string> GoogleAnalyticsDomains { get; set; }

    /// <summary>
    ///   Gets the headers.
    /// </summary>
    [JsonProperty("headers")]
    public JsonObject Headers { get; private set; }

    /// <summary>
    ///   Gets or sets the html.
    /// </summary>
    [JsonProperty("html")]
    public string Html { get; set; }

    /// <summary>
    ///   Gets or sets the images.
    /// </summary>
    [JsonProperty("images")]
    public IEnumerable<Image> Images { get; set; }

    /// <summary>
    ///   Get s or sets a value indicating whether important.
    /// </summary>
    [JsonProperty("important")]
    public bool? Important { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether inline_css.
    /// </summary>
    [JsonProperty("inline_css")]
    public bool? InlineCss { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether merge.
    /// </summary>
    [JsonProperty("merge")]
    public bool? Merge { get; set; }

    /// <summary>
    ///   Gets the merge_vars.
    /// </summary>
    [JsonProperty("merge_vars")]
    public List<RcptMergeVar> MergeVars { get; private set; }

    /// <summary>
    ///   Gets the metadata.
    /// </summary>
    [JsonProperty("metadata")]
    public JsonObject Metadata { get; private set; }

    /// <summary>
    ///   Gets or sets whether or not to expose all recipients in to "To" header for each email.
    /// </summary>
    [JsonProperty("preserve_recipients")]
    public bool PreserveRecipients { get; set; }

    /// <summary>
    ///   Gets or sets the raw_message.
    /// </summary>
    [JsonProperty("raw_message")]
    public string RawMessage { get; set; }

    /// <summary>
    ///   Gets or sets the string array to.
    /// </summary>
    [JsonProperty("raw_to")]
    public IEnumerable<string> RawTo { get; set; }

    /// <summary>
    ///   Gets or sets the recipient_metadata.
    /// </summary>
    [JsonProperty("recipient_metadata")]
    public IEnumerable<RcptMetadata> RecipientMetadata { get; set; }

    /// <summary>
    ///   Gets or sets the return_path_domain.
    /// </summary>
    [JsonProperty("return_path_domain")]
    public string ReturnPathDomain { get; set; }

    /// <summary>
    ///   Gets or sets the signing_domain.
    /// </summary>
    /// <remarks>
    ///   a custom domain to use for SPF/DKIM signing instead of mandrill (for "via" or "on behalf of" in email clients)
    /// </remarks>
    /// <value>
    ///   The signing_domain.
    /// </value>
    [JsonProperty("signing_domain")]
    public string SigningDomain { get; set; }

    /// <summary>
    ///   Gets or sets the subaccount.
    /// </summary>
    [JsonProperty("subaccount")]
    public string SubAccount { get; set; }

    /// <summary>
    ///   Gets or sets the subject.
    /// </summary>
    [JsonProperty("subject")]
    public string Subject { get; set; }

    /// <summary>
    ///   Gets or sets the merge language.
    /// </summary>
    [JsonProperty("merge_language")]
    public string MergeLanguage { get; set; }

    /// <summary>
    ///   Gets or sets the tags.
    /// </summary>
    [JsonProperty("tags")]
    public IEnumerable<string> Tags { get; set; }

    /// <summary>
    ///   Gets or sets the text.
    /// </summary>
    [JsonProperty("text")]
    public string Text { get; set; }

    /// <summary>
    ///   Gets or sets the to.
    /// </summary>
    [JsonProperty("to")]
    public IEnumerable<EmailAddress> To { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether track_clicks.
    /// </summary>
    [JsonProperty("track_clicks")]
    public bool? TrackClicks { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether track_opens.
    /// </summary>
    [JsonProperty("track_opens")]
    public bool? TrackOpens { get; set; }

    /// <summary>
    ///   Gets or sets the tracking_domain.
    /// </summary>
    /// <remarks>
    ///   a custom domain to use for tracking opens and clicks instead of mandrillapp.com
    /// </remarks>
    /// <value>
    ///   The tracking_domain.
    /// </value>
    [JsonProperty("tracking_domain")]
    public string TrackingDomain { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether url_strip_qs.
    /// </summary>
    [JsonProperty("url_strip_qs")]
    public bool? UrlStripQs { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether view_content_link
    /// </summary>
    [JsonProperty("view_content_link")]
    public bool? ViewContentLink { get; set; }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    ///   The add global variable.
    /// </summary>
    /// <param name="name">
    ///   The name.
    /// </param>
    /// <param name="content">
    ///   The content.
    /// </param>
    public void AddGlobalVariable(string name, string content)
    {
      if (GlobalMergeVars == null)
      {
        GlobalMergeVars = new List<MergeVar>();
      }

      var mv = new MergeVar {Name = name, Content = content};
      GlobalMergeVars.Add(mv);
    }

    /// <summary>
    ///   The add header.
    /// </summary>
    /// <param name="name">
    ///   The name.
    /// </param>
    /// <param name="value">
    ///   The value.
    /// </param>
    public void AddHeader(string name, string value)
    {
      if (Headers == null)
      {
        Headers = new JsonObject();
      }

      Headers[name] = value;
    }

    /// <summary>
    ///   The add metadata.
    /// </summary>
    /// <param name="key">
    ///   The key.
    /// </param>
    /// <param name="value">
    ///   The value.
    /// </param>
    public void AddMetadata(string key, string value)
    {
      if (Metadata == null)
      {
        Metadata = new JsonObject();
      }

      Metadata[key] = value;
    }

    /// <summary>
    ///   The add recipient variable.
    /// </summary>
    /// <param name="recipient">
    ///   The recipient.
    /// </param>
    /// <param name="name">
    ///   The name.
    /// </param>
    /// <param name="content">
    ///   The content.
    /// </param>
    public void AddRecipientVariable(string recipient, string name, string content)
    {
      if (MergeVars == null)
      {
        MergeVars = new List<RcptMergeVar>();
      }

      RcptMergeVar entry = MergeVars.Where(e => e.Rcpt == recipient).FirstOrDefault();
      if (entry == null)
      {
        entry = new RcptMergeVar {Rcpt = recipient};
        MergeVars.Add(entry);
      }

      var mv = new MergeVar {Name = name, Content = content};

      entry.Vars.Add(mv);
    }

    #endregion
  }
}