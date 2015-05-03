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
  public class UpdateTemplateTests : IntegrationTestBase
  {
    [Test]
    public async Task Can_Update_Template() {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string templateName = ConfigurationManager.AppSettings["TemplateExample"];
      const string original = "<span mc:edit=\"model1\"></span>";
      const string modified = "<span mc:edit=\"model2\"></span>";

      // Exercise
      var api = new MandrillApi(apiKey);
      TemplateInfo result = await api.UpdateTemplate(
        new UpdateTemplateRequest(templateName)
        {
          Code = modified
        });
      TemplateInfo result2 = await api.UpdateTemplate(
        new UpdateTemplateRequest(templateName) {
          Code = original
        });

      // Verify
      Assert.AreEqual(modified, result.Code);
      Assert.AreEqual(original, result2.Code);
    }

  }
}
