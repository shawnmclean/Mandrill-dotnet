using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Rejects;
using Mandrill.Utilities;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Rejects
{
  [TestFixture]
  public class DeleteRejectTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Delete_Reject()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string reject = ConfigurationManager.AppSettings["RejectDelete"];

      // Exercise
      var api = new MandrillApi(apiKey);

      //Verify
      RejectAddResult addResponse = await api.AddReject(new AddRejectRequest(reject));
      RejectDeleteResult deleteResponse = await api.DeleteReject(new DeleteRejectRequest(addResponse.Email));

      Assert.That(deleteResponse.Deleted, Is.True);
    }

    [Test]
    [Ignore("Response is returning true even when reject is not in the list.")]
    public async Task Should_Throw_Exception_On_Invalid_Reject()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string reject = "test@test.com";

      // Exercise
      var api = new MandrillApi(apiKey);

      //Verify
      var exception =
        Assert.Throws<MandrillException>(async () => await api.DeleteReject(new DeleteRejectRequest(reject)));
      Assert.That(exception.Error.Name, Is.EqualTo("Invalid_Reject"));
    }
  }
}