using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Senders;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Senders
{
  [TestFixture]
  public class CheckSenderDomainTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Return_Sender_Domain()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];

      // Exercise
      var api = new MandrillApi(apiKey);

      // Verify
      SenderDomain domain = await api.CheckSenderDomain(new SenderCheckDomainRequest("example.com"));
      Assert.IsNotNull(domain);
    }
  }
}