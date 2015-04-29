using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Mandrill.Models;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests
{
  [TestFixture]
  public class MessagesTests : IntegrationTestBase
  {
    [Test]
    public async Task Message_With_Send_At_Is_Scheduled_For_Paid_Account()
    {
      if (!IsPaidAccount)
        Assert.Ignore("Not a paid account");

      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
      string fromEmail = ConfigurationManager.AppSettings["FromEMail"];

      // Exercise
      var api = new MandrillApi(apiKey);

      List<EmailResult> result = await api.SendMessage(new EmailMessage
      {
        To =
          new List<EmailAddress> {new EmailAddress {Email = toEmail, Name = ""}},
        FromEmail = fromEmail,
        Subject = "Mandrill Integration Test",
        Html = "<strong>Scheduled Email</strong>",
        Text = "Example text"
      }, DateTime.UtcNow.AddMinutes(5.0));

      // Verify
      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(toEmail, result.First().Email);
      Assert.AreEqual(EmailResultStatus.Scheduled, result.First().Status);

      //Tear down
      api.CancelScheduledMessage(result.First().Id);
    }





    [Test]
    public async Task Scheduled_Message_Is_Canceled_For_Paid_Account()
    {
      if (!IsPaidAccount)
        Assert.Ignore("Not a paid account");
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
      string fromEmail = ConfigurationManager.AppSettings["FromEMail"];

      // Exercise
      var api = new MandrillApi(apiKey);

      List<EmailResult> messages = await api.SendMessage(new EmailMessage
      {
        To =
          new List<EmailAddress> {new EmailAddress {Email = toEmail, Name = ""}},
        FromEmail = fromEmail,
        Subject = "Mandrill Integration Test",
        Html = "<strong>Scheduled Email</strong>",
        Text = "Example text"
      }, DateTime.UtcNow.AddMinutes(5.0));

      List<ScheduledEmailResult> scheduled = api.ListScheduledMessages(toEmail);

      //Verify that message was scheduled
      Assert.AreEqual(1, scheduled.Count(s => s.Id == messages.First().Id));

      api.CancelScheduledMessage(messages.First().Id);
      scheduled = api.ListScheduledMessages(toEmail);

      //Verify that message was cancelled.
      Assert.AreEqual(0, scheduled.Count(s => s.Id == messages.First().Id));
    }

    [Test]
    public async Task Scheduled_Message_Is_Rescheduled_For_Paid_Account()
    {
      if (!IsPaidAccount)
        Assert.Ignore("Not a paid account");
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
      string fromEmail = ConfigurationManager.AppSettings["FromEMail"];

      // Exercise
      var api = new MandrillApi(apiKey);

      List<EmailResult> messages = await api.SendMessage(new EmailMessage
      {
        To =
          new List<EmailAddress> {new EmailAddress {Email = toEmail, Name = ""}},
        FromEmail = fromEmail,
        Subject = "Mandrill Integration Test",
        Html = "<strong>Scheduled Email</strong>",
        Text = "Example text"
      }, DateTime.UtcNow.AddMinutes(5.0));

      ScheduledEmailResult message = api.ListScheduledMessages().Find(s => s.Id == messages.First().Id);

      ScheduledEmailResult rescheduled = api.RescheduleMessage(message.Id, message.SendAt.AddMinutes(5.0));

      //Verify
      Assert.Greater(rescheduled.SendAt, message.SendAt);

      //Tear down
      api.CancelScheduledMessage(rescheduled.Id);
    }


  }
}