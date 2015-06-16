using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Messages;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Messages
{
  [TestFixture]
  public class InfoTests
  {
    [Test]
    [Ignore("Message may expire from mandrill servers")]
    public async Task Should_Get_Information_Of_A_Sent_Email()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string sentEmailId = ConfigurationManager.AppSettings["SentEmailId"];
      string sentEmailSubject = ConfigurationManager.AppSettings["SentEmailSubject"];
      string sentEmailRecipient = ConfigurationManager.AppSettings["SentEmailRecipient"];

      // Exercise
      var api = new MandrillApi(apiKey);

      MessageInfo response = await api.GetInfo(new MessageInfoRequest(sentEmailId));

      Assert.AreEqual(sentEmailSubject, response.Subject);
      Assert.AreEqual(sentEmailRecipient, response.Email);
    }
  }
}