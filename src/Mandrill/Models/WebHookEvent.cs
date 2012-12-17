using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mandrill
{
	public enum WebHookEventType
	{
		send, // message has been sent
		hard_bounce, // message has hard bounced
		soft_bounce, // message has soft bounced
		open, // recipient opened a message; will only occur when open tracking is enabled
		click, // recipient clicked a link in a message; will only occur when click tracking is enabled
		spam, // recipient marked a message as spam
		unsub, // recipient unsubscribed
		reject // message was rejected
	}

	public enum WebHookMessageState
	{
		sent,
		rejected,
		spam,
		unsub,
		bounced,
		soft_bounced
	}

	public class WebHookEvent
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public WebHookEventType Event { get; set; }

		public uint TS { get; set; }

		public DateTime TimeStamp {
			get {
				return FromUnixTime (TS);
			}
		}

		public WebHookMessage Msg { get; set; }
	
		public static DateTime FromUnixTime (long unixTime)
		{
			var epoch = new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return epoch.AddSeconds (unixTime);
		}
	}

	public class WebHookMessage
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public WebHookMessageState State { get; set; }

		public uint TS { get; set; }

		public DateTime TimeStamp {
			get {
				return WebHookEvent.FromUnixTime (TS);
			}
		}
	}
}
