using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Rejects;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Rejects
{
  [TestFixture]
  public class ListRejectsTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_List_Rejects()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string reject1 = ConfigurationManager.AppSettings["RejectAdd"] + Guid.NewGuid();
      string reject2 = ConfigurationManager.AppSettings["RejectAdd"] + Guid.NewGuid();

      // Exercise
      var api = new MandrillApi(apiKey);

      //Verify
      await api.AddReject(new AddRejectRequest(reject1));
      await api.AddReject(new AddRejectRequest(reject2));

      List<RejectInfo> response = await api.ListRejects(new ListRejectsRequest());

      // Verify
      Assert.Contains(reject1, response.Select(r => r.Email).ToList());
      Assert.Contains(reject2, response.Select(r => r.Email).ToList());

      // Cleanup
      await api.DeleteReject(new DeleteRejectRequest(reject1));
      await api.DeleteReject(new DeleteRejectRequest(reject2));
    }
  }
}