using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Templates;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Templates
{
  [TestFixture]
  public class ListTemplatesTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Return_Correct_Count()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      int templateCount = int.Parse(ConfigurationManager.AppSettings["TemplateCount"]);

      // Exercise
      var api = new MandrillApi(apiKey);
      List<TemplateInfo> result = await api.ListTemplates(new ListTemplatesRequest());

      int expected = templateCount;

      // Verify
      Assert.AreEqual(expected, result.Count);
    }

    [Test]
    public async Task Should_Return_Correct_Count_When_Searching_By_Label()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      int templateCount = int.Parse(ConfigurationManager.AppSettings["TemplateCountWithLabel"]);
      string label = ConfigurationManager.AppSettings["TemplateLabel"];

      // Exercise
      var api = new MandrillApi(apiKey);
      List<TemplateInfo> result = await api.ListTemplates(new ListTemplatesRequest {Label = label});

      int expected = templateCount;

      // Verify
      Assert.AreEqual(expected, result.Count);
    }
  }
}