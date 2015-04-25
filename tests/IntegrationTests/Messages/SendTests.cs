using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Messages
{
  [TestFixture]
  public class SendTests
  {
    [Test]
    public async Task Should_Send_Email_Message_Without_Template() {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
      string fromEmail = ConfigurationManager.AppSettings["FromEMail"];

      // Exercise
      var api = new MandrillApi(apiKey);

      List<EmailResult> result = await api.SendMessage(new EmailMessage {
        To =
          new List<EmailAddress> { new EmailAddress { Email = toEmail, Name = "" } },
        FromEmail = fromEmail,
        Subject = "Mandrill Integration Test",
        Html = "<strong>Example HTML</strong>",
        Text = "Example text"
      });

      // Verify
      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(toEmail, result.First().Email);
      Assert.AreEqual(EmailResultStatus.Sent, result.First().Status);
    }
  }
}
