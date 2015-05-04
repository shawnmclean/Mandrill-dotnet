using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Messages;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Messages
{
  [TestFixture]
  public class ContentTests
  {
    [Test]
    public async Task Should_Get_Content_Of_A_Sent_Email()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string sentEmailId = ConfigurationManager.AppSettings["SentEmailId"];
      string sentEmailSubject = ConfigurationManager.AppSettings["SentEmailSubject"];
      string sentEmailText = ConfigurationManager.AppSettings["SentEmailText"];

      // Exercise
      var api = new MandrillApi(apiKey);

      Content response = await api.GetContent(new ContentRequest(sentEmailId));

      Assert.AreEqual(sentEmailSubject, response.Subject);
      Assert.AreEqual(sentEmailText, response.Text);
    }
  }
}