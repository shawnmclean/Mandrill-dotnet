using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.SubAccounts;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.SubAccounts
{
  [TestFixture]
  public class ListSubAccountTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Return_List_Of_Sub_Accounts()
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

      SubaccountInfo addedSubaccount = await api.AddSubaccount(request);

      List<SubaccountInfo> result = await api.ListSubaccounts(new ListSubAccountsRequest());

      // Verify
      Assert.IsNotNull(result);
      Assert.IsNotEmpty(result);
      Assert.IsNotNull(result.Find(s => s.Id == addedSubaccount.Id));

      // Cleanup
      await api.DeleteSubaccount(new DeleteSubAccountRequest(addedSubaccount.Id));
    }
  }
}