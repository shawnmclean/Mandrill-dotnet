using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models.Requests;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.SubAccounts
{
  [TestFixture]
  public class AddSubAccountTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Add_SubAccount_And_Return() {
      // Setup
      var apiKey = ConfigurationManager.AppSettings["APIKey"];

      var request = new AddSubAccountRequest(Guid.NewGuid().ToString()) { CustomQuota = 10, Name = "subaccount1", Notes = "notes"};


      // Exercise
      var api = new MandrillApi(apiKey);

      var result = await api.AddSubaccount(request);

      // Verify
      Assert.IsNotNull(result);
      Assert.AreEqual(result.Id, request.Id);
      Assert.AreEqual(result.Name, request.Name);
      Assert.AreEqual(result.CustomQuota, request.CustomQuota);
      Assert.AreEqual(result.Status, "active");
    }
  }
}
