using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests
{
	[TestFixture()]
	public class WebHookTests
	{
		[Test()]
		public void Event_DeSerialize ()
		{
			string events_json = @"
[{
""event"":""send"",
""ts"":1355340679,
""msg"":{
 ""ts"":1355340679,
 ""subject"":""Important Stuff"",
 ""email"":""ValidToOne@Valid.com"",
 ""tags"":[],
 ""opens"":[],
 ""clicks"":[],
 ""state"":""sent"",
 ""_id"":""fc8071b3575e44228d5dd7059349ba10"",
 ""sender"":""ValidFrom@From.com""}
},{
""event"":""send"",
""ts"":1355340679,
""msg"":{
 ""ts"":1355340679,
 ""subject"":""Important Stuff"",
 ""email"":""ValidToTwo@Valid.com"",
 ""tags"":[],
 ""opens"":[],
 ""clicks"":[],
 ""state"":""sent"",
 ""_id"":""7572c81599d945cfb8dae3a8527f8232"",
 ""sender"":""ValidFrom@From.com""}
}]";
			var eventTimeDate = new DateTime (2012, 12, 12, 19, 31, 19);
			var numberOfEvents = 2;

			// Be sure we have two JSON object
			var zot = JSON.Parse<List<object>> (events_json);
			Assert.AreEqual (numberOfEvents, zot.Count);

			// Try parsing out WebHook events
			var events = JSON.Parse<List<WebHookEvent>> (events_json);
			Assert.AreEqual (numberOfEvents, events.Count);
			var e = events [0];

			Assert.AreEqual (WebHookEventType.send, e.Event);
			Assert.AreEqual (eventTimeDate, e.TimeStamp);

			var message = e.Msg;

			Assert.AreEqual (WebHookMessageState.sent, message.State);
			Assert.AreEqual (eventTimeDate, message.TimeStamp);
		}
	}
}
