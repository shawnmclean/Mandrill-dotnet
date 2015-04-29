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
  public class SendTemplateTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Send_Email_Message_With_Template() {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
      string fromEmail = ConfigurationManager.AppSettings["FromEMail"];
      string templateExample = ConfigurationManager.AppSettings["TemplateExample"];

      // Exercise
      var api = new MandrillApi(apiKey);

      var result = await api.SendMessageTemplate(new SendMessageTemplateRequest
      {
        Message = new EmailMessage
        {
          To =
            new List<EmailAddress> {new EmailAddress {Email = toEmail, Name = ""}},
          FromEmail = fromEmail,
          Subject = "Mandrill Integration Test",
        },
        TemplateName = templateExample,
        TemplateContents = new List<TemplateContent>
        {
          new TemplateContent {Name = "model1", Content = "Content1"},
          new TemplateContent {Name = "model2", Content = "Content2"}
        }
      });

      // Verify
      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(toEmail, result.First().Email);
      Assert.AreEqual(EmailResultStatus.Sent, result.First().Status);
    }

    [Test]
    public async Task Should_Send_Email_Message_With_Template_With_Send_At() {
      if (!IsPaidAccount)
        Assert.Ignore("Not a paid account");

      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
      string fromEmail = ConfigurationManager.AppSettings["FromEMail"];
      string templateExample = ConfigurationManager.AppSettings["TemplateExample"];

      // Exercise
      var api = new MandrillApi(apiKey);

      var result = await api.SendMessageTemplate(new SendMessageTemplateRequest {
        Message = new EmailMessage {
          To =
            new List<EmailAddress> { new EmailAddress { Email = toEmail, Name = "" } },
          FromEmail = fromEmail,
          Subject = "Mandrill Scheduled Integration Test",
        },
        TemplateName = templateExample,
        TemplateContents = new List<TemplateContent>
        {
          new TemplateContent {Name = "model1", Content = "Content1"},
          new TemplateContent {Name = "model2", Content = "Content2"}
        },
        SendAt = DateTime.Now.AddMinutes(5)
      });

      // Verify
      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(toEmail, result.First().Email);
      Assert.AreEqual(EmailResultStatus.Sent, result.First().Status);
    }
  }
}
