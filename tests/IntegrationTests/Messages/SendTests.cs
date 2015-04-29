using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Models.Requests;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Messages
{
  [TestFixture]
  public class SendTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Send_Email_Message_Without_Template() {
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
        }
      });

      // Verify
      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(toEmail, result.First().Email);
      Assert.AreEqual(EmailResultStatus.Sent, result.First().Status);
    }

    [Test]
    public async Task Message_With_Send_At_Is_Scheduled_For_Paid_Account() {
      if (!IsPaidAccount)
        Assert.Ignore("Not a paid account");

      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
      string fromEmail = ConfigurationManager.AppSettings["FromEMail"];

      // Exercise
      var api = new MandrillApi(apiKey);

      List<EmailResult> result = await api.SendMessage(new SendMessageRequest()
      {
        Message = new EmailMessage
        {
          To =
            new List<EmailAddress> {new EmailAddress {Email = toEmail, Name = ""}},
          FromEmail = fromEmail,
          Subject = "Mandrill Integration Test",
          Html = "<strong>Scheduled Email</strong>",
          Text = "Example text"
        },
        SendAt = DateTime.Now.AddMinutes(5)
      });

      // Verify
      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(toEmail, result.First().Email);
      Assert.AreEqual(EmailResultStatus.Scheduled, result.First().Status);

      //Tear down
      api.CancelScheduledMessage(result.First().Id);
    }
  }
}
