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
  public class SubAccountInfoTests : IntegrationTestBase
  {
    [Test]
    public async Task Subaccount_Info_Returns_Subaccount()
    {
      // Setup
      var apiKey = ConfigurationManager.AppSettings["APIKey"];

      var subaccount = new AddSubAccountRequest(Guid.NewGuid().ToString()) { CustomQuota = 10, Name = "subaccount1" };

      // Exercise
      var api = new MandrillApi(apiKey);

      var result = await api.AddSubaccount(subaccount);

      var infoSubaccount = await api.SubaccountInfo(new SubAccountInfoRequest(subaccount.Id));

      // Verify
      Assert.IsNotNull(infoSubaccount);
      Assert.AreEqual(infoSubaccount.Id, subaccount.Id);
    }
  }
}
