using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models.Requests;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Messages
{
  [TestFixture]
  public class InfoTests
  {
    [Test]
    public async Task Should_Get_Information_Of_A_Sent_Email()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string sentEmailId = ConfigurationManager.AppSettings["SentEmailId"];
      string sentEmailSubject = ConfigurationManager.AppSettings["SentEmailSubject"];
      string sentEmailRecipient = ConfigurationManager.AppSettings["SentEmailRecipient"];

      // Exercise
      var api = new MandrillApi(apiKey);

      var response = await api.GetInfo(new MessageInfoRequest{Id = sentEmailId});

      Assert.AreEqual(sentEmailSubject, response.Subject);
      Assert.AreEqual(sentEmailRecipient, response.Email);
    }
  }
}
