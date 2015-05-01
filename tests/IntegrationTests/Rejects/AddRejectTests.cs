using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models.Requests;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Rejects
{
  [TestFixture]
  public class AddRejectTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Add_Reject() {
      // Setup
      var apiKey = ConfigurationManager.AppSettings["APIKey"];
      string reject = ConfigurationManager.AppSettings["RejectAdd"];

      // Exercise
      var api = new MandrillApi(apiKey);

      //Verify
      var actual = await api.AddReject(new AddRejectRequest(reject));
      Assert.AreEqual(reject, actual.Email);
    }
  }
}
