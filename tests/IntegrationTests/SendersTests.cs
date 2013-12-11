using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Mandrill.Tests.IntegrationTests
{
    [TestFixture]
    public class SendersTests
    {
        public static bool Validator(object sender, X509Certificate certificate, X509Chain chain,
                                      SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        [TestFixtureSetUp]
        public void Init()
        {
            if (ConfigurationManager.AppSettings["IgnoreInvalidSSLCertificate"] == "True")
                ServicePointManager.ServerCertificateValidationCallback = Validator;
        }

        [Test]
        public void Senders_Returns_List()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];

            // Exercise
            var api = new MandrillApi(apiKey);

            // Verify
            //var senders = api.ListSenders();
            
        }

        [Test]
        public void SenderDomains_Returns_Domains()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];

            // Exercise
            var api = new MandrillApi(apiKey);

            // Verify
            var domains = api.SenderDomains();
        }

        [Test]
        public void CheckSenderDomain_Returns_Domain()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];

            // Exercise
            var api = new MandrillApi(apiKey);

            // Verify
            var domain = api.CheckSenderDomain("example.com");
            Assert.IsNotNull(domain);
        }
    }
}
