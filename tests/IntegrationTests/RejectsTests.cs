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
    public class RejectsTests
    {
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
            var ex = Assert.Throws<MandrillException>(() => api.DeleteReject(reject));
            Assert.That(ex.Error.name, Is.EqualTo("Invalid_Reject"));
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
            //TODO: test this....
        }
    }
}
