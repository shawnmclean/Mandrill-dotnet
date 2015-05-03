using System;
using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.SubAccounts;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.SubAccounts
{
  [TestFixture]
  public class SubAccountInfoTests : IntegrationTestBase
  {
    [Test]
    public async Task Subaccount_Info_Returns_Subaccount()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];

      var subaccount = new AddSubAccountRequest(Guid.NewGuid().ToString()) {CustomQuota = 10, Name = "subaccount1"};

      // Exercise
      var api = new MandrillApi(apiKey);

      SubaccountInfo result = await api.AddSubaccount(subaccount);

      SubaccountInfo infoSubaccount = await api.SubaccountInfo(new SubAccountInfoRequest(subaccount.Id));

      // Verify
      Assert.IsNotNull(infoSubaccount);
      Assert.AreEqual(infoSubaccount.Id, subaccount.Id);

      // Cleanup
      await api.DeleteSubaccount(new DeleteSubAccountRequest(subaccount.Id));
    }
  }
}