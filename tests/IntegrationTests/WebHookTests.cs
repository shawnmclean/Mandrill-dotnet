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
 ""opens"":[{""ts"":1355340679},{""ts"":1355412679}],
 ""state"":""sent"",
 ""clicks"":[{""ts"":1355773922,""url"":""http:\/\/www.GitHub.com""}],
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

			Assert.AreEqual (WebHookEventType.Send, e.Event);
			Assert.AreEqual (eventTimeDate, e.TimeStamp);

			var message = e.Msg;

			Assert.AreEqual (WebHookMessageState.Sent, message.State);
			Assert.AreEqual (eventTimeDate, message.TimeStamp);
			Assert.AreEqual ("Important Stuff", message.Subject);
			Assert.AreEqual ("ValidFrom@From.com", message.Sender);
			Assert.AreEqual ("ValidToOne@Valid.com", message.Email);
			Assert.AreEqual ("fc8071b3575e44228d5dd7059349ba10", message.Id);
			Assert.AreEqual (2,message.Opens.Count);
			Assert.AreEqual (eventTimeDate, message.Opens[0].TimeStamp);
			Assert.AreEqual (1,message.Clicks.Count);
			Assert.AreEqual ("http://www.GitHub.com",message.Clicks[0].Url);
		}
	}
}
