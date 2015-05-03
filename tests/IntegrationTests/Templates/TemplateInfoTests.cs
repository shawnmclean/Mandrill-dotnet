using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Templates;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Templates
{
  [TestFixture]
  public class TemplateInfoTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Get_Template_Info()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string templateName = ConfigurationManager.AppSettings["TemplateExample"];
      string expectedTemplate = "<span mc:edit=\"model1\"></span>";

      // Exercise
      var api = new MandrillApi(apiKey);
      TemplateInfo result = await api.TemplateInfo(new TemplateInfoRequest(templateName));

      // Verify
      Assert.AreEqual(templateName, result.Name);
      Assert.AreEqual(expectedTemplate, result.Code);
    }
  }
}