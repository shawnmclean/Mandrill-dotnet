using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Models.Requests;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.SubAccounts
{
  [TestFixture]
  public class DeleteSubAccountTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Delete_SubAccount_And_Returns_It() {
      // Setup
      var apiKey = ConfigurationManager.AppSettings["APIKey"];

      var request = new AddSubAccountRequest(Guid.NewGuid().ToString()) { CustomQuota = 10, Name = "subaccount1", Notes = "notes" };


      // Exercise
      var api = new MandrillApi(apiKey);

      var result = await api.AddSubaccount(request);

      var deletedSubaccount = await api.DeleteSubaccount(new DeleteSubAccountRequest(result.Id));

      // Verify
      Assert.IsNotNull(deletedSubaccount);
      Assert.AreEqual(deletedSubaccount.Id, result.Id);
    }

  }
}
