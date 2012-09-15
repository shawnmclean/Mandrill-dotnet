using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests
{
            [TestFixture]
    public class MessagesTests
    {
        [Test]
        public void Template_Message_Is_Sent()
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
                                                     new List<EmailAddress>
                                                         {new EmailAddress {email = toEmail, name = ""}},
                                                 from_email = fromEmail,
                                                 subject = "Mandrill Integration Test",
                                             }, "Test", new List<TemplateContent>{new TemplateContent{name="model1",content = "Content1"}, new TemplateContent{name = "model2", content = "Content2"}});

            // Verify
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(toEmail, result.First().Email);
            Assert.AreEqual(EmailResultStatus.Sent, result.First().Status);
        }
    }
}
