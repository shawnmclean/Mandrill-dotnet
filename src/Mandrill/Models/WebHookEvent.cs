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

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Reflection;

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
    [EnumMember(Value = "soft-bounced")] Soft_bounced,

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
    [JsonConverter(typeof (StringEnumConverter))]
    public WebHookEventType Event { get; set; }

    /// <summary>
    ///   Gets or sets the msg.
    /// </summary>
    public WebHookMessage Msg { get; set; }

    /// <summary>
    ///   Gets or sets the ts.
    /// </summary>
    public uint TS { get; set; }

    /// <summary>
    ///   Gets the time stamp.
    /// </summary>
    public DateTime TimeStamp
    {
      get { return FromUnixTime(TS); }
    }

    [JsonProperty("ip")]
    public string IP { get; set; }
    /// <summary>
    /// for click events only, the url clicked for the event
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// for open and click events only, the user agent string for the environment (ie, browser or email client) where the open or click occurred
    /// </summary>
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
    public Dictionary<string, EmailAttachment> Attachments { get; set; }

    /// <summary>
    ///   Gets or sets the bounce description.
    /// </summary>
    public string BounceDescription { get; set; }

    /// <summary>
    ///   Gets or sets the cc.
    /// </summary>
    public List<List<string>> CC { get; set; }

    /// <summary>
    ///   Gets or sets the clicks.
    /// </summary>
    public List<WebHookClick> Clicks { get; set; }

    /// <summary>
    ///   Gets or sets the diag.
    /// </summary>
    public string Diag { get; set; }

    /// <summary>
    ///   Gets or sets the dkim.
    /// </summary>
    public WebHookDkim Dkim { get; set; }

    /// <summary>
    ///   Gets or sets the email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///   Gets or sets the from email.
    /// </summary>
    public string FromEmail { get; set; }

    /// <summary>
    ///   Gets or sets the from name.
    /// </summary>
    public string FromName { get; set; }

	/// <summary>
	/// Gets or sets the headers.
	/// </summary>
	public Dictionary<string, dynamic> Headers { get; set; }

    /// <summary>
    ///   Gets or sets the html.
    /// </summary>
    public string Html { get; set; }

    /// <summary>
    ///   Gets or sets the id.
    /// </summary>
    [JsonProperty("_id")]
    public string Id { get; set; }

    /// <summary>
    ///   Gets or sets the images.
    /// </summary>
    public Dictionary<string, Image> Images { get; set; }

    /// <summary>
    ///   Gets or sets the metadata.
    /// </summary>
    [JsonConverter(typeof (MetadataConverter))]
    public List<WebHookMetadata> Metadata { get; set; }

    /// <summary>
    ///   Gets or sets the opens.
    /// </summary>
    public List<WebHookOpen> Opens { get; set; }

    /// <summary>
    ///   Gets or sets the raw msg.
    /// </summary>
    public string RawMsg { get; set; }

    /// <summary>
    ///   Gets or sets the sender.
    /// </summary>
    public string Sender { get; set; }

    /// <summary>
    ///   Gets or sets the smtp events.
    /// </summary>
    public List<SmtpEvent> SmtpEvents { get; set; }

    /// <summary>
    ///   Gets or sets the spf.
    /// </summary>
    public WebHookSpf Spf { get; set; }

    /// <summary>
    ///   Gets or sets the state.
    /// </summary>
    [JsonConverter(typeof (StringEnumConverter))]
    public WebHookMessageState State { get; set; }

    /// <summary>
    ///   Gets or sets the sub account
    /// </summary>
    [JsonProperty("subaccount")]
    public string SubAccount { get; set; }

    /// <summary>
    ///   Gets or sets the subject.
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    ///   Gets or sets the ts.
    /// </summary>
    public uint TS { get; set; }

    /// <summary>
    ///   Gets or sets the tags.
    /// </summary>
    public List<string> Tags { get; set; }

    /// <summary>
    ///   Gets or sets the template.
    /// </summary>
    public string Template { get; set; }

    /// <summary>
    ///   Gets or sets the text.
    /// </summary>
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
    public List<List<string>> To { get; set; }

    #endregion

    /// <summary>
    ///   The metadata converter.
    /// </summary>
    private class MetadataConverter : JsonConverter
    {
      #region Public Methods and Operators

      /// <summary>
      ///   The can convert.
      /// </summary>
      /// <param name="objectType">
      ///   The object type.
      /// </param>
      /// <returns>
      ///   The <see cref="bool" />.
      /// </returns>
      public override bool CanConvert(Type objectType)
      {
        return typeof (WebHookMetadata).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
      }

      /// <summary>
      ///   The read json.
      /// </summary>
      /// <param name="reader">
      ///   The reader.
      /// </param>
      /// <param name="objectType">
      ///   The object type.
      /// </param>
      /// <param name="existingValue">
      ///   The existing value.
      /// </param>
      /// <param name="serializer">
      ///   The serializer.
      /// </param>
      /// <returns>
      ///   The <see cref="object" />.
      /// </returns>
      public override object ReadJson(
        JsonReader reader,
        Type objectType,
        object existingValue,
        JsonSerializer serializer)
      {
        JObject jObject = JObject.Load(reader);

        var list = new List<WebHookMetadata>();

        foreach (var prop in jObject)
        {
          list.Add(new WebHookMetadata {Key = prop.Key, Value = prop.Value.ToString()});
        }

        return list;
      }

      /// <summary>
      ///   The write json.
      /// </summary>
      /// <param name="writer">
      ///   The writer.
      /// </param>
      /// <param name="value">
      ///   The value.
      /// </param>
      /// <param name="serializer">
      ///   The serializer.
      /// </param>
      /// <exception cref="NotImplementedException">
      /// </exception>
      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
        if (value == null) return;

        //generate JSON for WebHookMetadata
        var webHookMetadata = value as List<WebHookMetadata>;

        if (webHookMetadata == null)
        {
          writer.WriteNull();
          return;
        }

        writer.WriteStartObject();

        foreach (var metadata in webHookMetadata)
        {
          writer.WritePropertyName(metadata.Key);
          serializer.Serialize(writer, metadata.Value);  
        }
        
        writer.WriteEndObject();
      }

      #endregion
    }
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
    public string Url { get; set; }

    #endregion
  }

  /// <summary>
  ///   The web hook metadata.
  /// </summary>
  public class WebHookMetadata
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the key.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    ///   Gets or sets the value.
    /// </summary>
    public string Value { get; set; }

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
    public bool Signed { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether valid.
    /// </summary>
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
    public string Detail { get; set; }

    /// <summary>
    ///   Gets or sets the result.
    /// </summary>
    public string Result { get; set; }

    #endregion
  }
}
