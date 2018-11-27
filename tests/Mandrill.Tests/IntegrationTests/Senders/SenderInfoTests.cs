using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Senders;
using Xunit;

namespace Mandrill.Tests.IntegrationTests.Senders
{
  [TestFixture]
  public class SenderInfoTests
  {
    [Test]
    public async Task Should_Return_Sender()
    {
        // Setup
        string apiKey = ConfigurationManager.AppSettings["APIKey"];
        
        // Exercise
        var api = new MandrillApi(apiKey);

        // Verify
        Sender sender = await api.SenderInfo(new SenderInfoRequest("testaddress@test.com"));

        Assert.IsNotNull(sender);
    }
  }
}
