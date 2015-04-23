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
    public const string mailchimp = "mailchimp";

    /// <summary>
    ///   Uses the handlebars template syntax.
    /// </summary>
    public const string handlebars = "handlebars";
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
    public IEnumerable<EmailAttachment> attachments { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether auto_html.
    /// </summary>
    public bool? auto_html { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether auto_text.
    /// </summary>
    public bool? auto_text { get; set; }

    /// <summary>
    ///   Gets or sets the bcc_address.
    /// </summary>
    public string bcc_address { get; set; }

    /// <summary>
    ///   Gets or sets the from_email.
    /// </summary>
    public string from_email { get; set; }

    /// <summary>
    ///   Gets or sets the from_name.
    /// </summary>
    public string from_name { get; set; }

    /// <summary>
    ///   Gets the global_merge_vars.
    /// </summary>
    public List<MergeVar> global_merge_vars { get; private set; }

    /// <summary>
    ///   Gets or sets the google_analytics_campaign.
    ///   TODO the api docs state that this can be a string or an array
    /// </summary>
    public string google_analytics_campaign { get; set; }

    /// <summary>
    ///   Gets or sets the google_analytics_domains.
    /// </summary>
    public IEnumerable<string> google_analytics_domains { get; set; }

    /// <summary>
    ///   Gets the headers.
    /// </summary>
    public JsonObject headers { get; private set; }

    /// <summary>
    ///   Gets or sets the html.
    /// </summary>
    public string html { get; set; }

    /// <summary>
    ///   Gets or sets the images.
    /// </summary>
    public IEnumerable<Image> images { get; set; }

    /// <summary>
    ///   Get s or sets a value indicating whether important.
    /// </summary>
    public bool? important { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether inline_css.
    /// </summary>
    public bool? inline_css { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether merge.
    /// </summary>
    public bool? merge { get; set; }

    /// <summary>
    ///   Gets the merge_vars.
    /// </summary>
    public List<RcptMergeVar> merge_vars { get; private set; }

    /// <summary>
    ///   Gets the metadata.
    /// </summary>
    public JsonObject metadata { get; private set; }

    /// <summary>
    ///   Gets or sets whether or not to expose all recipients in to "To" header for each email.
    /// </summary>
    public bool preserve_recipients { get; set; }

    /// <summary>
    ///   Gets or sets the raw_message.
    /// </summary>
    public string raw_message { get; set; }

    /// <summary>
    ///   Gets or sets the string array to.
    /// </summary>
    public IEnumerable<string> raw_to { get; set; }

    /// <summary>
    ///   Gets or sets the recipient_metadata.
    /// </summary>
    public IEnumerable<RcptMetadata> recipient_metadata { get; set; }

    /// <summary>
    ///   Gets or sets the return_path_domain.
    /// </summary>
    public string return_path_domain { get; set; }

    /// <summary>
    ///   Gets or sets the signing_domain.
    /// </summary>
    /// <remarks>
    ///   a custom domain to use for SPF/DKIM signing instead of mandrill (for "via" or "on behalf of" in email clients)
    /// </remarks>
    /// <value>
    ///   The signing_domain.
    /// </value>
    public string signing_domain { get; set; }

    /// <summary>
    ///   Gets or sets the subaccount.
    /// </summary>
    public string subaccount { get; set; }

    /// <summary>
    ///   Gets or sets the subject.
    /// </summary>
    public string subject { get; set; }

    /// <summary>
    ///   Gets or sets the merge language.
    /// </summary>
    public string merge_language { get; set; }

    /// <summary>
    ///   Gets or sets the tags.
    /// </summary>
    public IEnumerable<string> tags { get; set; }

    /// <summary>
    ///   Gets or sets the text.
    /// </summary>
    public string text { get; set; }

    /// <summary>
    ///   Gets or sets the to.
    /// </summary>
    public IEnumerable<EmailAddress> to { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether track_clicks.
    /// </summary>
    public bool? track_clicks { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether track_opens.
    /// </summary>
    public bool? track_opens { get; set; }

    /// <summary>
    ///   Gets or sets the tracking_domain.
    /// </summary>
    /// <remarks>
    ///   a custom domain to use for tracking opens and clicks instead of mandrillapp.com
    /// </remarks>
    /// <value>
    ///   The tracking_domain.
    /// </value>
    public string tracking_domain { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether url_strip_qs.
    /// </summary>
    public bool? url_strip_qs { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether view_content_link
    /// </summary>
    public bool? view_content_link { get; set; }

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
      if (global_merge_vars == null)
      {
        global_merge_vars = new List<MergeVar>();
      }

      var mv = new MergeVar {Name = name, Content = content};
      global_merge_vars.Add(mv);
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
      if (headers == null)
      {
        headers = new JsonObject();
      }

      headers[name] = value;
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
      if (metadata == null)
      {
        metadata = new JsonObject();
      }

      metadata[key] = value;
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
      if (merge_vars == null)
      {
        merge_vars = new List<RcptMergeVar>();
      }

      RcptMergeVar entry = merge_vars.Where(e => e.Rcpt == recipient).FirstOrDefault();
      if (entry == null)
      {
        entry = new RcptMergeVar {Rcpt = recipient};
        merge_vars.Add(entry);
      }

      var mv = new MergeVar {Name = name, Content = content};

      entry.Vars.Add(mv);
    }

    #endregion
  }
}