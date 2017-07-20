using System;
using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.SubAccounts;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.SubAccounts
{
  [TestFixture]
  public class UpdateSubAccountTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Update_And_Return()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      var request = new AddSubAccountRequest(Guid.NewGuid().ToString())
      {
        CustomQuota = 10,
        Name = "subaccount1",
        Notes = "notes"
      };

      // Exercise
      var api = new MandrillApi(apiKey);

      SubaccountInfo result = await api.AddSubaccount(request);


      string newName = result.Name + "2";

      var updatedAccount = new UpdateSubAccountRequest(request.Id)
      {
        Name = newName
      };

      SubaccountInfo updated = await api.UpdateSubaccount(updatedAccount);

      // Verify
      Assert.IsNotNull(updated);
      Assert.AreEqual(updated.Id, request.Id);
      Assert.AreEqual(updated.Name, newName);

      // Cleanup
      await api.DeleteSubaccount(new DeleteSubAccountRequest(updatedAccount.Id));
    }
  }
}