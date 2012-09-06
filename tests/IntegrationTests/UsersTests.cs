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
        public void lol()
        {
            var apiKey = ConfigurationManager.AppSettings["APIKey"];

        }
    }
}
