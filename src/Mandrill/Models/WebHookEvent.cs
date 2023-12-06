// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebHookEvent.cs" company="">
//   
// </copyright>
// <summary>
//   The web hook event type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/* http://help.mandrill.com/entries/21738186-introduction-to-webhooks
   Simple MVC Controller example
   [ValidateInput(false)] // May be required if accepting inbound webhooks, http://msdn.microsoft.com/en-us/library/hh882339.aspx
   [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post | HttpVerbs.Head)]
   public ActionResult Hook(string id, FormCollection val) {
    //...
    var events = Mandrill.JSON.Parse<List<Mandrill.WebHookEvent>> (val.Get("mandrill_events"));
    //...
    return View();
   }
*/

using Mandrill.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  /// <summary>
  ///   The web hook event type.
  /// </summary>
  public enum WebHookEventType
  {
    /// <summary>
    ///   The send.
    /// </summary>
    Send, // message has been sent

    /// <summary>
    ///   The delivered.
    /// </summary>
    Delivered, // message has been delivered
    
    /// <summary>
    ///   The hard_bounce.
    /// </summary>
    Hard_bounce, // message has hard bounced

    /// <summary>
    ///   The soft_bounce.
    /// </summary>
    Soft_bounce, // message has soft bounced

    /// <summary>
    ///   The open.
    /// </summary>
    Open, // recipient opened a message; will only occur when open tracking is enabled

    /// <summary>
    ///   The click.
    /// </summary>
    Click, // recipient clicked a link in a message; will only occur when click tracking is enabled

    /// <summary>
    ///   The spam.
    /// </summary>
    Spam, // recipient marked a message as spam

    /// <summary>
    ///   The unsub.
    /// </summary>
    Unsub, // recipient unsubscribed

    /// <summary>
    ///   The reject.
    /// </summary>
    Reject, // message was rejected

    /// <summary>
    ///   The deferral.
    /// </summary>
    Deferral, // message have been deferred

    /// <summary>
    ///   The inbound.
    /// </summary>
    Inbound // Inbound message, more info at http://help.mandrill.com/categories/20102127-Inbound-Email-Processing
  }

  /// <summary>
  ///   The web hook message state.
  /// </summary>
  public enum WebHookMessageState
  {
    /// <summary>
    ///   The sent.
    /// </summary>
    Sent,

    /// <summary>
    ///   The rejected.
    /// </summary>
    Rejected,

    /// <summary>
    ///   The spam.
    /// </summary>
    Spam,

    /// <summary>
    ///   The unsub.
    /// </summary>
    Unsub,

    /// <summary>
    ///   The bounced.
    /// </summary>
    Bounced,

    /// <summary>
    ///   The soft_bounced.
    /// </summary>
    [EnumMember(Value = "soft-bounced")]
    Soft_bounced,

    /// <summary>
    ///   The deferred.
    /// </summary>
    Deferred,

    /// <summary>
    ///   The inbound.
    /// </summary>
    Inbound
  }

  /// <summary>
  ///   The web hook event.
  /// </summary>
  public class WebHookEvent
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the event.
    /// </summary>
    [JsonPropertyName("event")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public WebHookEventType Event { get; set; }

    /// <summary>
    ///   Gets or sets the msg.
    /// </summary>
    [JsonPropertyName("msg")]
    public WebHookMessage Msg { get; set; }

    /// <summary>
    ///   Gets or sets the ts.
    /// </summary>
    [JsonPropertyName("ts")]
    public uint TS { get; set; }

    /// <summary>
    ///   Gets the time stamp.
    /// </summary>
    public DateTime TimeStamp
    {
      get { return FromUnixTime(TS); }
    }

    [JsonPropertyName("ip")]
    public string IP { get; set; }
    /// <summary>
    /// for click events only, the url clicked for the event
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    /// for open and click events only, the user agent string for the environment (ie, browser or email client) where the open or click occurred
    /// </summary>
    [JsonPropertyName("user_agent")]
    public string UserAgent { get; set; }
    #endregion

    #region Public Methods and Operators

    /// <summary>
    ///   The from unix time.
    /// </summary>
    /// <param name="unixTime">
    ///   The unix time.
    /// </param>
    /// <returns>
    ///   The <see cref="DateTime" />.
    /// </returns>
    public static DateTime FromUnixTime(long unixTime)
    {
      var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      return epoch.AddSeconds(unixTime);
    }

    #endregion

    // TODO Need to find the time zone for Mandrill time stamps
  }

  /// <summary>
  ///   The web hook message.
  /// </summary>
  public class WebHookMessage
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the attachments.
    /// </summary>
    [JsonPropertyName("attachments")]
    public Dictionary<string, EmailAttachment> Attachments { get; set; }

    /// <summary>
    ///   Gets or sets the bounce description.
    /// </summary>
    [JsonPropertyName("bounce_description")]
    public string BounceDescription { get; set; }

    /// <summary>
    ///   Gets or sets the cc.
    /// </summary>
    [JsonPropertyName("cc")]
    public List<List<string>> CC { get; set; }

    /// <summary>
    ///   Gets or sets the clicks.
    /// </summary>
    [JsonPropertyName("clicks")]
    public List<WebHookClick> Clicks { get; set; }

    /// <summary>
    ///   Gets or sets the diag.
    /// </summary>
    [JsonPropertyName("diag")]
    public string Diag { get; set; }

    /// <summary>
    ///   Gets or sets the dkim.
    /// </summary>
    [JsonPropertyName("dkim")]
    public WebHookDkim Dkim { get; set; }

    /// <summary>
    ///   Gets or sets the email.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    ///   Gets or sets the from email.
    /// </summary>
    [JsonPropertyName("from_email")]
    public string FromEmail { get; set; }

    /// <summary>
    ///   Gets or sets the from name.
    /// </summary>
    [JsonPropertyName("from_name")]
    public string FromName { get; set; }

    /// <summary>
    /// Gets or sets the headers.
    /// </summary>
    [JsonPropertyName("headers")]
    public Dictionary<string, dynamic> Headers { get; set; }

    /// <summary>
    ///   Gets or sets the html.
    /// </summary>
    [JsonPropertyName("html")]
    public string Html { get; set; }

    /// <summary>
    ///   Gets or sets the id.
    /// </summary>
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    /// <summary>
    ///   Gets or sets the images.
    /// </summary>
    [JsonPropertyName("images")]
    public Dictionary<string, Image> Images { get; set; }

    /// <summary>
    ///   Gets or sets the metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    [JsonConverter(typeof(DictionaryJsonConverter<object>))]
    public Dictionary<string, object> Metadata { get; set; }

    /// <summary>
    ///   Gets or sets the opens.
    /// </summary>
    [JsonPropertyName("opens")]
    public List<WebHookOpen> Opens { get; set; }

    /// <summary>
    ///   Gets or sets the raw msg.
    /// </summary>
    [JsonPropertyName("raw_msg")]
    public string RawMsg { get; set; }

    /// <summary>
    ///   Gets or sets the sender.
    /// </summary>
    [JsonPropertyName("sender")]
    public string Sender { get; set; }

    /// <summary>
    ///   Gets or sets the smtp events.
    /// </summary>
    [JsonPropertyName("smtp_events")]
    public List<SmtpEvent> SmtpEvents { get; set; }

    /// <summary>
    ///   Gets or sets the spf.
    /// </summary>
    [JsonPropertyName("spf")]
    public WebHookSpf Spf { get; set; }

    /// <summary>
    ///   Gets or sets the state.
    /// </summary>
    [JsonPropertyName("state")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public WebHookMessageState State { get; set; }

    /// <summary>
    ///   Gets or sets the sub account
    /// </summary>
    [JsonPropertyName("subaccount")]
    public string SubAccount { get; set; }

    /// <summary>
    ///   Gets or sets the subject.
    /// </summary>
    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    /// <summary>
    ///   Gets or sets the ts.
    /// </summary>
    [JsonPropertyName("ts")]
    public uint TS { get; set; }

    /// <summary>
    ///   Gets or sets the tags.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    /// <summary>
    ///   Gets or sets the template.
    /// </summary>
    [JsonPropertyName("template")]
    public string Template { get; set; }

    /// <summary>
    ///   Gets or sets the text.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; }

    /// <summary>
    ///   Gets the time stamp.
    /// </summary>
    public DateTime TimeStamp
    {
      get { return WebHookEvent.FromUnixTime(TS); }
    }

    /// <summary>
    ///   Gets or sets the to.
    /// </summary>
    [JsonPropertyName("to")]
    public List<List<string>> To { get; set; }

    #endregion
  }

  /// <summary>
  ///   The web hook open.
  /// </summary>
  public class WebHookOpen
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the ts.
    /// </summary>
    [JsonPropertyName("ts")]
    public uint TS { get; set; }

    /// <summary>
    ///   Gets the time stamp.
    /// </summary>
    public DateTime TimeStamp
    {
      get { return WebHookEvent.FromUnixTime(TS); }
    }

    #endregion
  }

  /// <summary>
  ///   The web hook click.
  /// </summary>
  public class WebHookClick
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the ts.
    /// </summary>
    [JsonPropertyName("ts")]
    public uint TS { get; set; }

    /// <summary>
    ///   Gets the time stamp.
    /// </summary>
    public DateTime TimeStamp
    {
      get { return WebHookEvent.FromUnixTime(TS); }
    }

    /// <summary>
    ///   Gets or sets the url.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    #endregion
  }

  /// <summary>
  ///   The web hook dkim.
  /// </summary>
  public class WebHookDkim
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets a value indicating whether signed.
    /// </summary>
    [JsonPropertyName("signed")]
    public bool Signed { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether valid.
    /// </summary>
    [JsonPropertyName("valid")]
    public bool Valid { get; set; }

    #endregion
  }

  /// <summary>
  ///   The web hook spf.
  /// </summary>
  public class WebHookSpf
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the detail.
    /// </summary>
    [JsonPropertyName("detail")]
    public string Detail { get; set; }

    /// <summary>
    ///   Gets or sets the result.
    /// </summary>
    [JsonPropertyName("result")]
    public string Result { get; set; }

    #endregion
  }
}
