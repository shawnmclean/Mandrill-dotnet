using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mandrill.Models;
using NUnit.Framework;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Mandrill.Tests.IntegrationTests
{
    [TestFixture]
    public class MessagesTests
    {
        private bool _isPaidAccount;
        public static bool Validator (object sender, X509Certificate certificate, X509Chain chain, 
                                      SslPolicyErrors sslPolicyErrors) {
            return true;
        }

        [TestFixtureSetUp]
        public void Init () {
            if (ConfigurationManager.AppSettings["IgnoreInvalidSSLCertificate"] == "True")
                ServicePointManager.ServerCertificateValidationCallback = Validator;

            _isPaidAccount = ConfigurationManager.AppSettings["IsPaidAccount"] == "True";
        }

        [Test]
        public async Task Message_Without_Template_Is_Sent()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
            string fromEmail = ConfigurationManager.AppSettings["FromEMail"];

            // Exercise
            var api = new MandrillApi(apiKey);

            var result = await api.SendMessage(new EmailMessage
            {
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

        [Test]
        public async Task Template_Message_Is_Sent()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
            string fromEmail = ConfigurationManager.AppSettings["FromEMail"];
            string templateExample = ConfigurationManager.AppSettings["TemplateExample"];

            // Exercise
            var api = new MandrillApi(apiKey);

            var result = await api.SendMessage(new EmailMessage
                                             {
                                                 To =
                                                     new List<EmailAddress> { new EmailAddress { Email = toEmail, Name = "" } },
                                                 FromEmail = fromEmail,
                                                 Subject = "Mandrill Integration Test",
                                             }, templateExample, new List<TemplateContent> { new TemplateContent { name = "model1", content = "Content1" }, new TemplateContent { name = "model2", content = "Content2" } });

            // Verify
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(toEmail, result.First().Email);
            Assert.AreEqual(EmailResultStatus.Sent, result.First().Status);
        }

        [Test]
        [Ignore("Need a unique existing email")]
        public void Can_Search_Message()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
            string fromEmail = ConfigurationManager.AppSettings["FromEMail"];
            string subjSKey = ConfigurationManager.AppSettings["UniqueExistingEmailSubject"];

            // Exercise
            var api = new MandrillApi(apiKey);


            var search = new Search
            {
                Query = String.Format(@"subject:{0}", subjSKey),
                Limit = "10"
            };

            var result = api.Search(search);

            //Verify 2
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(subjSKey, result[0].Subject);
        }

        [Test]
        public void Raw_Message_Is_Sent ()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
            string fromEmail = ConfigurationManager.AppSettings["FromEMail"];

            // Exercise
            var api = new MandrillApi(apiKey);

            var message = "From: " + fromEmail + "\n" +
                "Subject: Mandrill Integration Test Raw\n" +
                "To: " + toEmail + "\n" +
                "MIME-Version: 1.0\n" +
                "Content-Type: text/html; charset=utf-8\n" +
                "Content-Transfer-Encoding: 7bit\n" +
                "\n" +
                "Test\n";
            var result = api.SendRawMessage(new EmailMessage
                                             {
                                                 To =
                                                     new List<EmailAddress> { new EmailAddress { Email = toEmail, Name = "" } },
                                                 FromEmail = fromEmail,
                                                 FromName = "",
                                                 RawMessage = message,
                                                 RawTo = new List<string> { toEmail }
                                             });
            // Verify
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(toEmail, result.First().Email);
            Assert.AreEqual(EmailResultStatus.Sent, result.First().Status);

        }

        [Test]
        public async Task Message_With_Send_At_Is_Scheduled_For_Paid_Account()
        {
            if(!_isPaidAccount)
                Assert.Ignore("Not a paid account");

            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
            string fromEmail = ConfigurationManager.AppSettings["FromEMail"];

            // Exercise
            var api = new MandrillApi(apiKey);

            var result = await api.SendMessage(new EmailMessage
            {
                To =
                    new List<EmailAddress> { new EmailAddress { Email = toEmail, Name = "" } },
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
        public async Task Scheduled_Message_Is_Rescheduled_For_Paid_Account()
        {
            if (!_isPaidAccount)
                Assert.Ignore("Not a paid account");
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
            string fromEmail = ConfigurationManager.AppSettings["FromEMail"];

            // Exercise
            var api = new MandrillApi(apiKey);

            var messages = await api.SendMessage(new EmailMessage
                {
                    To =
                        new List<EmailAddress> { new EmailAddress { Email = toEmail, Name = "" } },
                    FromEmail = fromEmail,
                    Subject = "Mandrill Integration Test",
                    Html = "<strong>Scheduled Email</strong>",
                    Text = "Example text"
                }, DateTime.UtcNow.AddMinutes(5.0));

            var message = api.ListScheduledMessages().Find(s => s.Id == messages.First().Id);

            var rescheduled = api.RescheduleMessage(message.Id, message.SendAt.AddMinutes(5.0));

            //Verify
            Assert.Greater(rescheduled.SendAt, message.SendAt);

            //Tear down
            api.CancelScheduledMessage(rescheduled.Id);
        }

        [Test]
        public async Task Scheduled_Message_Is_Canceled_For_Paid_Account()
        {
            if (!_isPaidAccount)
                Assert.Ignore("Not a paid account");
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
            string fromEmail = ConfigurationManager.AppSettings["FromEMail"];

            // Exercise
            var api = new MandrillApi(apiKey);

            var messages = await api.SendMessage(new EmailMessage
            {
                To =
                    new List<EmailAddress> { new EmailAddress { Email = toEmail, Name = "" } },
                FromEmail = fromEmail,
                Subject = "Mandrill Integration Test",
                Html = "<strong>Scheduled Email</strong>",
                Text = "Example text"
            }, DateTime.UtcNow.AddMinutes(5.0));

            var scheduled = api.ListScheduledMessages(toEmail);

            //Verify that message was scheduled
            Assert.AreEqual(1, scheduled.Count(s => s.Id == messages.First().Id));

            api.CancelScheduledMessage(messages.First().Id);
            scheduled = api.ListScheduledMessages(toEmail);

            //Verify that message was cancelled.
            Assert.AreEqual(0, scheduled.Count(s => s.Id == messages.First().Id));

        }

    }
}
