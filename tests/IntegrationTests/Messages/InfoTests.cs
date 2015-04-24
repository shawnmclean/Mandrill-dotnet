using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Messages
{
  [TestFixture]
  public class InfoTests
  {
    [Test]
    public async Task Should_Send_New_Info_Instruction()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string sentEmailId = ConfigurationManager.AppSettings["SentEmailId"];
      string sentEmailSubject = ConfigurationManager.AppSettings["SentEmailSubject"];
      string sentEmailText = ConfigurationManager.AppSettings["SentEmailText"];

      // Exercise
      var api = new MandrillApi(apiKey);

      var response = await api.Info(sentEmailId);

      Assert.AreEqual(sentEmailSubject, response.Subject);
      //Assert.AreEqual(sentEmailText, response.Text);
    }
  }
}
