using System;
using System.Collections.Generic;
using Mandrill.Models;
using Mandrill.Utilities;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests
{
  [TestFixture]
  public class WebHookTests
  {
    [Test]
    public void Event_DeSerialize()
    {
      string events_json = @"
[{
""event"":""send"",
""ts"":1355340679,
""url"": ""http://clicked.me"",
""ip"": ""127.0.0.1"",
""user_agent"": ""outlook"",
""msg"":{
 ""ts"":1355340679,
 ""subject"":""Important Stuff"",
 ""email"":""ValidToOne@Valid.com"",
 ""tags"":[""tag1"",""tag2"",""tag3""],
 ""metadata"":{ ""key1"":""val1"", ""key2"":""val2"" },
 ""opens"":[{""ts"":1355340679},{""ts"":1355412679}],
 ""state"":""sent"",
 ""clicks"":[{""ts"":1355773922,""url"":""http:\/\/www.GitHub.com""}],
 ""_id"":""fc8071b3575e44228d5dd7059349ba10"",
 ""sender"":""ValidFrom@From.com"",
 ""template"":""validTemplate"",
 ""subaccount"":""validSubAccount""}
},{
""event"":""send"",
""ts"":1355340679,
""msg"":{
 ""ts"":1355340679,
 ""subject"":""Important Stuff"",
 ""email"":""ValidToTwo@Valid.com"",
 ""tags"":[],
 ""metadata"":{ },
 ""opens"":[],
 ""clicks"":[],
 ""state"":""sent"",
 ""_id"":""7572c81599d945cfb8dae3a8527f8232"",
 ""sender"":""ValidFrom@From.com"",
 ""template"":""validTemplate"",
 ""subaccount"":""validSubAccount""}
}]";

      var eventTimeDate = new DateTime(2012, 12, 12, 19, 31, 19);
      int numberOfEvents = 2;

      // Be sure we have two JSON object
      var zot = JSON.Parse<List<object>>(events_json);
      Assert.AreEqual(numberOfEvents, zot.Count);

      // Try parsing out WebHook events
      var events = JSON.Parse<List<WebHookEvent>>(events_json);
      Assert.AreEqual(numberOfEvents, events.Count);
      WebHookEvent e = events[0];

      Assert.AreEqual("http://clicked.me", e.Url);
      Assert.AreEqual("127.0.0.1", e.IP);
      Assert.AreEqual("outlook", e.UserAgent);

      Assert.AreEqual(WebHookEventType.Send, e.Event);
      Assert.AreEqual(eventTimeDate, e.TimeStamp);

      WebHookMessage message = e.Msg;
      

      Assert.AreEqual("validSubAccount", message.SubAccount);
      Assert.AreEqual("validTemplate", message.Template);
      Assert.AreEqual(WebHookMessageState.Sent, message.State);
      Assert.AreEqual(eventTimeDate, message.TimeStamp);
      Assert.AreEqual("Important Stuff", message.Subject);
      Assert.AreEqual("ValidFrom@From.com", message.Sender);
      Assert.AreEqual("ValidToOne@Valid.com", message.Email);
      Assert.AreEqual("fc8071b3575e44228d5dd7059349ba10", message.Id);

      Assert.AreEqual(3, message.Tags.Count);
      Assert.AreEqual("tag1", message.Tags[0]);
      Assert.AreEqual("tag2", message.Tags[1]);
      Assert.AreEqual("tag3", message.Tags[2]);

      Assert.AreEqual(2, message.Metadata.Count);
      Assert.AreEqual("key1", message.Metadata[0].Key);
      Assert.AreEqual("val1", message.Metadata[0].Value);
      Assert.AreEqual("key2", message.Metadata[1].Key);
      Assert.AreEqual("val2", message.Metadata[1].Value);

      Assert.AreEqual(2, message.Opens.Count);
      Assert.AreEqual(eventTimeDate, message.Opens[0].TimeStamp);
      Assert.AreEqual(1, message.Clicks.Count);
      Assert.AreEqual("http://www.GitHub.com", message.Clicks[0].Url);
    }

    [Test]
    public void Soft_Bounce_Deserialize()
    {
      string events_json = @"[{
    ""event"": ""soft_bounce"",
    ""msg"": {
      ""ts"": 1365109999,
      ""subject"": ""This an example webhook message"",
      ""email"": ""example.webhook@mandrillapp.com"",
      ""sender"": ""example.sender@mandrillapp.com"",
      ""tags"": [
        ""webhook-example""
      ],
      ""state"": ""soft-bounced"",
      ""metadata"": {
        ""user_id"": 111
      },
      ""_id"": ""exampleaaaaaaaaaaaaaaaaaaaaaaaaa"",
      ""_version"": ""exampleaaaaaaaaaaaaaaa"",
      ""bounce_description"": ""mailbox_full"",
      ""bgtools_code"": 22,
      ""diag"": ""smtp;552 5.2.2 Over Quota""
    }
  }]";
      var events = JSON.Parse<List<WebHookEvent>>(events_json);
      Assert.AreEqual(1, events.Count);
      Assert.AreEqual(WebHookMessageState.Soft_bounced, events[0].Msg.State);
    }

    [Test]
    public void Event_Serialize()
    {
      var webhook = 
        new WebHookEvent
        {
          Event = WebHookEventType.Click,
          IP = "127.0.0.1",
          TS = 1355340679,
          Url = "http://clicked.me",
          UserAgent = "outlook",
          Msg = new WebHookMessage
          {
            TS = 1355340679,
            Subject = "Important Stuff",
            Email = "ValidToOne@Valid.com",
            Tags = new List<string> { "tag1", "tag2", "tag3" },
            Metadata = new List<WebHookMetadata>
            {
              new WebHookMetadata { Key = "key1", Value = "val1" },
              new WebHookMetadata { Key = "key2", Value = "val2" }
            },
            Opens = new List<WebHookOpen>
            {
                new WebHookOpen { TS = 1355340679 },
                new WebHookOpen { TS = 1355340679 }
            },
            State = WebHookMessageState.Sent,
            Clicks = new List<WebHookClick>
            {
                new WebHookClick { TS = 1355773922, Url = @"http:\\www.GitHub.com"}
            },
            Id = "fc8071b3575e44228d5dd7059349ba10",
            Sender = "ValidFrom@From.com",
            Template = "ValidTemplate",
            SubAccount = "validSubAccount"
          }
        };

      var output = JSON.Serialize(webhook);
      var clone = JSON.Parse<WebHookEvent>(output);
      Assert.That(webhook.Msg.Metadata.Count == clone.Msg.Metadata.Count);
    }
  }
}