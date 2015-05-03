using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Senders
{
  [TestFixture]
  public class ListSendersTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Return_Senders()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];

      // Exercise
      var api = new MandrillApi(apiKey);

      // Verify
      List<Sender> senders = await api.ListSenders();

      Assert.IsNotNull(senders);
    }
  }
}