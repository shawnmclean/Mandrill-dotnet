using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mandrill.Models;
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

      var response = await api.Content(sentEmailId);

      Assert.AreEqual(sentEmailSubject, response.Subject);
      Assert.AreEqual(sentEmailText, response.Text);
    }
  }
}
