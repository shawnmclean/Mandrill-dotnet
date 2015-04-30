using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models.Requests;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Senders
{
  [TestFixture]
  public class CheckSenderDomainTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Return_Sender_Domain() {
      // Setup
      var apiKey = ConfigurationManager.AppSettings["APIKey"];

      // Exercise
      var api = new MandrillApi(apiKey);

      // Verify
      var domain = await api.CheckSenderDomain(new SenderCheckDomainRequest("example.com"));
      Assert.IsNotNull(domain);
    }
  }
}
