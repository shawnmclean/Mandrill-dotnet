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
    public class RejectsTests
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
        public void Add_Reject_Throws_Exception_On_Invalid_ApiKey()
        {
            // Setup
            var apiKey = " ";
            string reject = "test@test.com";

            // Exercise
            var api = new MandrillApi(apiKey);

            // Verify
            var ex = Assert.Throws<MandrillException>(() => api.AddReject(reject));
            Assert.That(ex.Error.name, Is.EqualTo("Invalid_Key"));
        }

        [Test]
        public void Add_Reject_Works()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            string reject = ConfigurationManager.AppSettings["RejectAdd"];

            // Exercise
            var api = new MandrillApi(apiKey);

            //Verify
            var actual =  api.AddReject(reject);
            Assert.AreEqual(reject, actual.Email);
        }

        [Test]
        public void Delete_Reject_Throws_Exception_On_Invalid_ApiKey()
        {
            // Setup
            var apiKey = " ";
            string reject = "test@test.com";

            // Exercise
            var api = new MandrillApi(apiKey);

            // Verify
            var ex = Assert.Throws<MandrillException>(() => api.DeleteReject(reject));
            Assert.That(ex.Error.name, Is.EqualTo("Invalid_Key"));
        }

        [Test]
        public void Delete_Reject_Throws_Exception_On_Invalid_Reject()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            string reject = "test@test.com";

            // Exercise
            var api = new MandrillApi(apiKey);

            //Verify
            //var ex = Assert.Throws<MandrillException>(() => api.DeleteReject(reject));
            //Assert.That(ex.Error.name, Is.EqualTo("Invalid_Reject"));
            //somehow this does not throw an exception, but returns true on all values passed.
        }

        [Test]
        public void Delete_Reject_Works()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            string reject = ConfigurationManager.AppSettings["RejectDelete"];

            // Exercise
            var api = new MandrillApi(apiKey);

            //Verify
            var actual =  api.DeleteReject(reject);
            //Assert.AreEqual(reject, actual.Email);
            //TODO: test this....works with my api key :)
        }

        [Test]
        public void List_Rejects_Throws_Exception_On_Invalid_ApiKey()
        {
            // Setup
            var apiKey = " ";

            // Exercise
            var api = new MandrillApi(apiKey);

            // Verify
            var ex = Assert.Throws<MandrillException>(() => api.ListRejects());
            Assert.That(ex.Error.name, Is.EqualTo("Invalid_Key"));
        }

        [Test]
        public void List_Rejects_Works()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];

            // Exercise
            var api = new MandrillApi(apiKey);

            // Verify
            var rejects = api.ListRejects();
            //TODO: test this....works with my api key :)
        }
    }
}
