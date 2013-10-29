using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

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
namespace Mandrill
{
    public enum WebHookEventType
    {
        Send, // message has been sent
        Hard_bounce, // message has hard bounced
        Soft_bounce, // message has soft bounced
        Open, // recipient opened a message; will only occur when open tracking is enabled
        Click, // recipient clicked a link in a message; will only occur when click tracking is enabled
        Spam, // recipient marked a message as spam
        Unsub, // recipient unsubscribed
        Reject, // message was rejected
        Deferral, // message have been deferred
        Inbound // Inbound message, more info at http://help.mandrill.com/categories/20102127-Inbound-Email-Processing
    }


    public enum WebHookMessageState
    {
        Sent,
        Rejected,
        Spam,
        Unsub,
        Bounced,
        [EnumMember(Value = "soft-bounced")]
        Soft_bounced,
        Deferred, 
        Inbound 
    }

    public class WebHookEvent
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public WebHookEventType Event { get; set; }

        public uint TS { get; set; }

        public DateTime TimeStamp
        {
            get
            {
                return FromUnixTime(TS);
            }
        }

        public WebHookMessage Msg { get; set; }

        // TODO Need to find the time zone for Mandrill time stamps
        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }
    }

    public class WebHookMessage
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public WebHookMessageState State { get; set; }

        public uint TS { get; set; }

        public DateTime TimeStamp
        {
            get
            {
                return WebHookEvent.FromUnixTime(TS);
            }
        }
        [JsonProperty("from_email")]
        public string FromEmail { get; set; }

        [JsonProperty("from_name")]
        public string FromName { get; set; }

        public string Sender { get; set; }

        public string Subject { get; set; }

        public string Email { get; set; }

        public string Html { get; set; }

        public string Text { get; set; }

        public List<WebHookOpen> Opens { get; set; }

        public List<WebHookClick> Clicks { get; set; }

        public List<string> Tags { get; set; }

        public Dictionary<string, attachment> Attachments { get; set; }
        public Dictionary<string, image> Images { get; set; }

        [JsonProperty("smtp_events")]
        public List<SmtpEvent> SmtpEvents { get; set; }

        [JsonConverter(typeof(MetadataConverter))]
        public List<WebHookMetadata> Metadata { get; set; }

        public string Diag { get; set; }

        public string BounceDescription { get; set; }

        public WebHookDkim Dkim { get; set; }

        public WebHookSpf Spf { get; set; }

        [JsonProperty("raw_msg ")]
        public string RawMsg { get; set; }

        class MetadataConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JObject jObject = JObject.Load(reader);

                var list = new List<WebHookMetadata>();

                foreach (var prop in jObject)
                {
                    list.Add(new WebHookMetadata { Key = prop.Key, Value = prop.Value.ToString() });
                }

                return list;
            }

            public override bool CanConvert(Type objectType)
            {
                return typeof(WebHookMetadata).IsAssignableFrom(objectType);
            }
        }
    }

    public class WebHookOpen
    {
        public uint TS { get; set; }

        public DateTime TimeStamp
        {
            get
            {
                return WebHookEvent.FromUnixTime(TS);
            }
        }
    }

    public class WebHookClick
    {
        public uint TS { get; set; }

        public DateTime TimeStamp
        {
            get
            {
                return WebHookEvent.FromUnixTime(TS);
            }
        }

        public string Url { get; set; }
    }

    public class WebHookMetadata
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    
    public class WebHookDkim
    {
        public bool Signed { get; set; }
        public bool Valid { get; set; }
    }

    public class WebHookSpf
    {
        public string Result { get; set; }
        public string Detail { get; set; }
    }
}
