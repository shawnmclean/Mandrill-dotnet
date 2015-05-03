using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Users
{
  [TestFixture]
  public class InfoTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Return_Info()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string username = ConfigurationManager.AppSettings["Username"];

      // Exercise
      var api = new MandrillApi(apiKey);
      UserInfo result = await api.UserInfo();

      // Verify
      Assert.AreEqual(username, result.Username);
    }

    [Test]
    public async Task Should_Throw_Exception_On_Invalid_ApiKey()
    {
      // Setup
      string apiKey = " ";

      // Exercise
      var api = new MandrillApi(apiKey);

      // Verify
      var ex = Assert.Throws<MandrillException>(async () => await api.UserInfo());
      Assert.That(ex.Error.Name, Is.EqualTo("Invalid_Key"));
    }
  }
}