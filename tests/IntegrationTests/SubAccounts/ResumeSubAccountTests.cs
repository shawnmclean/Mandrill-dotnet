using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.SubAccounts;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.SubAccounts
{
  [TestFixture]
  public class ResumeSubAccountTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Resume_And_Return_Sub_Account() {
      // Setup
      var apiKey = ConfigurationManager.AppSettings["APIKey"];

      var request = new AddSubAccountRequest(Guid.NewGuid().ToString()) { CustomQuota = 10, Name = "subaccount1", Notes = "notes" };


      // Exercise
      var api = new MandrillApi(apiKey);

      var result = await api.AddSubaccount(request);

      var paused = await api.PauseSubaccount(new PauseSubAccountRequest(request.Id));

      var resumed = await api.ResumeSubaccount(new ResumeSubAccountRequest(request.Id));

      // Verify
      Assert.IsNotNull(paused);
      Assert.AreEqual(paused.Id, request.Id);
      Assert.AreEqual(resumed.Status, "active");

      // Cleanup
      await api.DeleteSubaccount(new DeleteSubAccountRequest(result.Id));
    }
  }
}
