using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Requests.Rejects;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Rejects
{
  [TestFixture]
  public class DeleteRejectTests : IntegrationTestBase
  {

    [Test]
    [Ignore("Response is returning true even when reject is not in the list.")]
    public async Task Should_Throw_Exception_On_Invalid_Reject() {
      // Setup
      var apiKey = ConfigurationManager.AppSettings["APIKey"];
      string reject = "test@test.com";

      // Exercise
      var api = new MandrillApi(apiKey);

      //Verify
      var exception = Assert.Throws<MandrillException>(async () => await api.DeleteReject(new DeleteRejectRequest(reject)));
      Assert.That(exception.Error.Name, Is.EqualTo("Invalid_Reject"));
    }

    [Test]
    public async Task Should_Delete_Reject() {
      // Setup
      var apiKey = ConfigurationManager.AppSettings["APIKey"];
      string reject = ConfigurationManager.AppSettings["RejectDelete"];

      // Exercise
      var api = new MandrillApi(apiKey);

      //Verify
      var addResponse = await api.AddReject(new AddRejectRequest(reject));
      var deleteResponse = await api.DeleteReject(new DeleteRejectRequest(addResponse.Email));
      
      Assert.That(deleteResponse.Deleted, Is.True);
    }
  }
}
