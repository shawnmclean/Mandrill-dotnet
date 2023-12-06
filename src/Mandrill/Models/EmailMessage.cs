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
using System.Text.Json.Serialization;

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
    [JsonPropertyName("content")]
    public dynamic Content { get; set; }

    /// <summary>
    ///   The name.
    /// </summary>
    [JsonPropertyName("name")]
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
    [JsonPropertyName("rcpt")]
    public string Rcpt { get; set; }

    /// <summary>
    ///   The vars.
    /// </summary>
    [JsonPropertyName("vars")]
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
    [JsonPropertyName("rcpt")]
    public string Rcpt { get; set; }

    /// <summary>
    ///   The values.
    /// </summary>
    [JsonPropertyName("values")]
    public dynamic Values { get; set; }

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
    [JsonPropertyName("content")]
    public string Content { get; set; }

    /// <summary>
    ///   The name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///   The type.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    ///   True if the attachment is base64 encoded
    /// </summary>
    [JsonPropertyName("base64")]
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
    [JsonPropertyName("content")]
    public string Content { get; set; }

    /// <summary>
    ///   The name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///   The type.
    /// </summary>
    [JsonPropertyName("type")]
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
    [JsonPropertyName("attachments")]
    public IEnumerable<EmailAttachment> Attachments { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether auto_html.
    /// </summary>
    [JsonPropertyName("auto_html")]
    public bool? AutoHtml { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether auto_text.
    /// </summary>
    [JsonPropertyName("auto_text")]
    public bool? AutoText { get; set; }

    /// <summary>
    ///   Gets or sets the bcc_address.
    /// </summary>
    [JsonPropertyName("bcc_address")]
    public string BccAddress { get; set; }

    /// <summary>
    ///   Gets or sets the from_email.
    /// </summary>
    [JsonPropertyName("from_email")]
    public string FromEmail { get; set; }

    /// <summary>
    ///   Gets or sets the from_name.
    /// </summary>
    [JsonPropertyName("from_name")]
    public string FromName { get; set; }

    /// <summary>
    ///   Gets the global_merge_vars.
    /// </summary>
    [JsonPropertyName("global_merge_vars")]
    public List<MergeVar> GlobalMergeVars { get; private set; }

    /// <summary>
    ///   Gets or sets the google_analytics_campaign.
    ///   TODO the api docs state that this can be a string or an array
    /// </summary>
    [JsonPropertyName("google_analytics_campaign")]
    public string GoogleAnalyticsCampaign { get; set; }

    /// <summary>
    ///   Gets or sets the google_analytics_domains.
    /// </summary>
    [JsonPropertyName("google_analytics_domains")]
    public IEnumerable<string> GoogleAnalyticsDomains { get; set; }

    /// <summary>
    ///   Gets the headers.
    /// </summary>
    [JsonPropertyName("headers")]
    public Dictionary<string, string> Headers { get; private set; }

    /// <summary>
    ///   Gets or sets the html.
    /// </summary>
    [JsonPropertyName("html")]
    public string Html { get; set; }

    /// <summary>
    ///   Gets or sets the images.
    /// </summary>
    [JsonPropertyName("images")]
    public IEnumerable<Image> Images { get; set; }

    /// <summary>
    ///   Get s or sets a value indicating whether important.
    /// </summary>
    [JsonPropertyName("important")]
    public bool? Important { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether inline_css.
    /// </summary>
    [JsonPropertyName("inline_css")]
    public bool? InlineCss { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether merge.
    /// </summary>
    [JsonPropertyName("merge")]
    public bool? Merge { get; set; }

    /// <summary>
    ///   Gets the merge_vars.
    /// </summary>
    [JsonPropertyName("merge_vars")]
    public List<RcptMergeVar> MergeVars { get; private set; }

    /// <summary>
    ///   Gets the metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; private set; }

    /// <summary>
    ///   Gets or sets whether or not to expose all recipients in to "To" header for each email.
    /// </summary>
    [JsonPropertyName("preserve_recipients")]
    public bool? PreserveRecipients { get; set; }

    /// <summary>
    ///   Gets or sets the raw_message.
    /// </summary>
    [JsonPropertyName("raw_message")]
    public string RawMessage { get; set; }

    /// <summary>
    ///   Gets or sets the string array to.
    /// </summary>
    [JsonPropertyName("raw_to")]
    public IEnumerable<string> RawTo { get; set; }

    /// <summary>
    ///   Gets or sets the recipient_metadata.
    /// </summary>
    [JsonPropertyName("recipient_metadata")]
    public IEnumerable<RcptMetadata> RecipientMetadata { get; set; }

    /// <summary>
    ///   Gets or sets the return_path_domain.
    /// </summary>
    [JsonPropertyName("return_path_domain")]
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
    [JsonPropertyName("signing_domain")]
    public string SigningDomain { get; set; }

    /// <summary>
    ///   Gets or sets the subaccount.
    /// </summary>
    [JsonPropertyName("subaccount")]
    public string SubAccount { get; set; }

    /// <summary>
    ///   Gets or sets the subject.
    /// </summary>
    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    /// <summary>
    ///   Gets or sets the merge language.
    /// </summary>
    [JsonPropertyName("merge_language")]
    public string MergeLanguage { get; set; }

    /// <summary>
    ///   Gets or sets the tags.
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string> Tags { get; set; }

    /// <summary>
    ///   Gets or sets the text.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; }

    /// <summary>
    ///   Gets or sets the to.
    /// </summary>
    [JsonPropertyName("to")]
    public IEnumerable<EmailAddress> To { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether track_clicks.
    /// </summary>
    [JsonPropertyName("track_clicks")]
    public bool? TrackClicks { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether track_opens.
    /// </summary>
    [JsonPropertyName("track_opens")]
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
    [JsonPropertyName("tracking_domain")]
    public string TrackingDomain { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether url_strip_qs.
    /// </summary>
    [JsonPropertyName("url_strip_qs")]
    public bool? UrlStripQs { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether view_content_link
    /// </summary>
    [JsonPropertyName("view_content_link")]
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
    public void AddGlobalVariable(string name, dynamic content)
    {
      if (GlobalMergeVars == null)
      {
        GlobalMergeVars = new List<MergeVar>();
      }

      var mv = new MergeVar { Name = name, Content = content };
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
        Headers = new Dictionary<string, string>();
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
        Metadata = new Dictionary<string, string>();
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
    public void AddRecipientVariable(string recipient, string name, dynamic content)
    {
      if (MergeVars == null)
      {
        MergeVars = new List<RcptMergeVar>();
      }

      var entry = MergeVars.Where(e => e.Rcpt == recipient).FirstOrDefault();
      if (entry == null)
      {
        entry = new RcptMergeVar { Rcpt = recipient };
        MergeVars.Add(entry);
      }

      var mv = new MergeVar { Name = name, Content = content };

      entry.Vars.Add(mv);
    }
    #endregion
  }
}