using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Templates;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Templates
{
  [TestFixture]
  public class RenderTemplateTests : IntegrationTestBase
  {
    [Test]
    public async Task Render_Template_Returns_Correct_Content() {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string templateName = ConfigurationManager.AppSettings["TemplateExample"];

      // Exercise
      var api = new MandrillApi(apiKey);
      var templateContent = new TemplateContent {
        Content = "Test",
        Name = "model1"
      };
      RenderedTemplate result = await api.Render(new RenderTemplateRequest(templateName)
      {
        TemplateContent = new List<TemplateContent>{ templateContent}
      });

      string expected = "<span>Test</span>";

      // Verify
      Assert.AreEqual(expected, result.Html);
    }
  }
}
