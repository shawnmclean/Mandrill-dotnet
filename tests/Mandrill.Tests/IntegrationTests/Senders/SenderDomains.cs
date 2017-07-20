using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Senders
{
  [TestFixture]
  public class SenderDomains : IntegrationTestBase
  {
    [Test]
    public async Task Should_Return_Sender_Domains()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];

      // Exercise
      var api = new MandrillApi(apiKey);

      // Verify
      Task<List<SenderDomain>> domains = api.SenderDomains();


      Assert.IsNotNull(domains);
    }
  }
}