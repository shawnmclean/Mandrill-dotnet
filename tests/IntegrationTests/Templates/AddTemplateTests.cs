using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Templates;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests.Templates
{
  [TestFixture]
  public class AddTemplateTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Create_And_Delete_Template()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string templateName = ConfigurationManager.AppSettings["TemplateExample"] + "_temp";
      const string code = "Foobar";

      // Exercise
      var api = new MandrillApi(apiKey);
      TemplateInfo result = await api.AddTemplate(new AddTemplateRequest(templateName)
      {
        FromName = "test@test.invalid",
        Code = code,
        Text = code,
        Publish = true
      });
      TemplateInfo result2 = await api.DeleteTemplate(new DeleteTemplateRequest(templateName));

      // Verify
      Assert.AreEqual(code, result.Code);
      Assert.AreEqual(code, result2.Code);
    }
  }
}