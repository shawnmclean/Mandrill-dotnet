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
    public class UsersTests
    {
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
            Assert.That(ex.Error.name, Is.EqualTo("Invalid_Key"));
        }
    }
}
