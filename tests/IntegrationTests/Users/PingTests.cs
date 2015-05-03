using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Utilities;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Users
{
  [TestFixture]
  public class PingTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Return_Pong_On_Valid_ApiKey()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];

      // Exercise
      var api = new MandrillApi(apiKey);
      string result = await api.Ping();

      string expected = "PONG!";

      // Verify
      Assert.AreEqual(expected, result);
    }

    [Test]
    public async Task Should_Throw_Exception_On_Invalid_ApiKey()
    {
      // Setup
      string apiKey = " ";

      // Exercise
      var api = new MandrillApi(apiKey);

      // Verify
      var ex = Assert.Throws<MandrillException>(async () => await api.Ping());
      Assert.That(ex.Error.Name, Is.EqualTo("Invalid_Key"));
    }
  }
}