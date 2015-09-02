using System;
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
      string templateName = Guid.NewGuid().ToString();
      const string code = "Foobar";

      // Exercise
      var api = new MandrillApi(apiKey);
      await api.AddTemplate(new AddTemplateRequest(templateName)
      {
        FromName = "test@test.invalid",
        Code = code,
        Text = code,
        Publish = true
      });


      TemplateInfo result = await api.TemplateInfo(new TemplateInfoRequest(templateName));

      // Verify
      Assert.AreEqual(templateName, result.Name);
      Assert.AreEqual(code, result.Code);

      // Cleanup
      await api.DeleteTemplate(new DeleteTemplateRequest(templateName));
    }
  }
}