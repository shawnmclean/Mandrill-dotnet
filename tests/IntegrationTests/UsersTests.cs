using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Mandrill.Tests.IntegrationTests
{
    [TestFixture]
    public class UsersTests
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
        public void Ping_Returns_Pong_On_Valid_ApiKey()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            
            // Exercise
            var api = new MandrillApi(apiKey);
            string result = api.Ping();

            string expected = "\"PONG!\"";
            
            // Verify
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Ping_Throws_Exception_On_Invalid_ApiKey()
        {
            // Setup
            var apiKey = " ";

            // Exercise
            var api = new MandrillApi(apiKey);
            
            // Verify
            var ex = Assert.Throws<MandrillException>(() => api.Ping());
            Assert.That(ex.Error.Name, Is.EqualTo("Invalid_Key"));
        }

        [Test]
        public void UserInfo_Throws_Exception_On_Invalid_ApiKey()
        {
            // Setup
            var apiKey = " ";

            // Exercise
            var api = new MandrillApi(apiKey);

            // Verify
            var ex = Assert.Throws<MandrillException>(() => api.UserInfo());
            Assert.That(ex.Error.Name, Is.EqualTo("Invalid_Key"));
        }
    }
}
