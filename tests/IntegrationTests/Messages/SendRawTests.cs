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
  public class SendRawTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Send_Raw_Message()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
      string fromEmail = ConfigurationManager.AppSettings["FromEMail"];

      // Exercise
      var api = new MandrillApi(apiKey);

      string message = "From: " + fromEmail + "\n" +
                       "Subject: Mandrill Integration Test Raw\n" +
                       "To: " + toEmail + "\n" +
                       "MIME-Version: 1.0\n" +
                       "Content-Type: text/html; charset=utf-8\n" +
                       "Content-Transfer-Encoding: 7bit\n" +
                       "\n" +
                       "Test\n";
      List<EmailResult> result = await api.SendRawMessage(new SendRawMessageRequest
      {
        ToEmails = new List<string> {toEmail},
        FromEmail = fromEmail,
        FromName = "",
        RawMessage = message,
      });
      // Verify
      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(toEmail, result.First().Email);
      Assert.AreEqual(EmailResultStatus.Sent, result.First().Status);
    }
  }
}