using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Senders
{
  [TestFixture]
  public class ListSendersTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Return_Senders() {
      // Setup
      var apiKey = ConfigurationManager.AppSettings["APIKey"];

      // Exercise
      var api = new MandrillApi(apiKey);

      // Verify
      var senders = await api.ListSenders();

      Assert.IsNotNull(senders);
    }
  }
}
