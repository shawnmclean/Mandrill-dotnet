using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Mandrill.Tests.IntegrationTests
{
    [TestFixture]
    public class MessagesTests
    {
        public static bool Validator (object sender, X509Certificate certificate, X509Chain chain, 
                                      SslPolicyErrors sslPolicyErrors) {
            return true;
        }

        [TestFixtureSetUp]
        public void Init () {
            if (ConfigurationManager.AppSettings["IgnoreInvalidSSLCertificate"] == "True")
                ServicePointManager.ServerCertificateValidationCallback = Validator;
        }

        [Test]
        public void Message_Without_Template_Is_Sent()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
            string fromEmail = ConfigurationManager.AppSettings["FromEMail"];

            // Exercise
            var api = new MandrillApi(apiKey);

            var result = api.SendMessage(new EmailMessage
            {
                to =
                    new List<EmailAddress> { new EmailAddress { email = toEmail, name = "" } },
                from_email = fromEmail,
                subject = "Mandrill Integration Test",
                html = "<strong>Example HTML</strong>",
                text = "Example text"
            });

            // Verify
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(toEmail, result.First().Email);
            Assert.AreEqual(EmailResultStatus.Sent, result.First().Status);
        }

        [Test]
        public void Template_Message_Is_Sent()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            string toEmail = ConfigurationManager.AppSettings["ValidToEmail"];
            string fromEmail = ConfigurationManager.AppSettings["FromEMail"];
            string templateExample = ConfigurationManager.AppSettings["TemplateExample"];

            // Exercise
            var api = new MandrillApi(apiKey);

            var result = api.SendMessage(new EmailMessage
                                             {
                                                 to =
                                                     new List<EmailAddress> { new EmailAddress { email = toEmail, name = "" } },
                                                 from_email = fromEmail,
                                                 subject = "Mandrill Integration Test",
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
                query = String.Format(@"subject:{0}", subjSKey),
                limit = "10"
            };

            var result = api.Search(search);

            //Verify 2
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(subjSKey, result[0].subject);
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
                                                 to =
                                                     new List<EmailAddress> { new EmailAddress { email = toEmail, name = "" } },
                                                 from_email = fromEmail,
                                                 from_name = "",
                                                 raw_message = message
                                             });
            // Verify
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(toEmail, result.First().Email);
            Assert.AreEqual(EmailResultStatus.Sent, result.First().Status);

        }
    }
}
