using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Messages;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Messages
{
  [TestFixture]
  public class RescheduleMessageTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Reschedule_Message()
    {
      if (!IsPaidAccount)
        Assert.Ignore("Not a paid account");
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
      string fromEmail = ConfigurationManager.AppSettings["FromEMail"];

      // Exercise
      var api = new MandrillApi(apiKey);

      List<EmailResult> result = await api.SendMessage(new SendMessageRequest
      {
        Message = new EmailMessage
        {
          To =
            new List<EmailAddress> {new EmailAddress {Email = toEmail, Name = ""}},
          FromEmail = fromEmail,
          Subject = "Mandrill Integration Test",
          Html = "<strong>Example HTML</strong>",
          Text = "Example text"
        },
        SendAt = DateTime.Now.AddMinutes(5)
      });

      ScheduledEmailResult rescheduleResponse =
        await api.RescheduleMessage(new RescheduleMessageRequest(result.First().Id, DateTime.Now.AddMinutes(10)));

      Assert.AreEqual(result.First().Id, rescheduleResponse.Id);
    }
  }
}