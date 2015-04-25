using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Models.Payloads;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Messages
{
  [TestFixture]
  public class SearchTests
  {
    [Test]
    public async Task Should_Return_Messages_Matching_Search_Criteria()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string subjSKey = ConfigurationManager.AppSettings["UniqueExistingEmailSubject"];

      // Exercise
      var api = new MandrillApi(apiKey);


      var search = new Search {
        Query = String.Format(@"subject:{0}", subjSKey),
        Limit = "10"
      };

     var result = await api.Search(search);

      //Verify 2
      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(subjSKey, result[0].Subject);
    }
  }
}
