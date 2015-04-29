using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Users
{
  [TestFixture]
  public  class InfoTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Return_Info()
    {
      // Setup
      var apiKey = ConfigurationManager.AppSettings["APIKey"];
      var username = ConfigurationManager.AppSettings["Username"];

      // Exercise
      var api = new MandrillApi(apiKey);
      var result = await api.UserInfo();
      
      // Verify
      Assert.AreEqual(username, result.Username);
    }

    [Test]
    public async Task Should_Throw_Exception_On_Invalid_ApiKey() {
      // Setup
      var apiKey = " ";

      // Exercise
      var api = new MandrillApi(apiKey);

      // Verify
      var ex = Assert.Throws<MandrillException>(async () => await api.UserInfo());
      Assert.That(ex.Error.Name, Is.EqualTo("Invalid_Key"));
    }
  }
}
