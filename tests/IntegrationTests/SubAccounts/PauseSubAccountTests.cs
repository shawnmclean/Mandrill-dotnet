using System;
using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.SubAccounts;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.SubAccounts
{
  [TestFixture]
  public class PauseSubAccountTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Pause_And_Return_Sub_Account()
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

      SubaccountInfo paused = await api.PauseSubaccount(new PauseSubAccountRequest(request.Id));

      // Verify
      Assert.IsNotNull(paused);
      Assert.AreEqual(paused.Id, request.Id);
      Assert.AreEqual(paused.Status, "paused");

      // Cleanup
      await api.DeleteSubaccount(new DeleteSubAccountRequest(result.Id));
    }
  }
}