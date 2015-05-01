using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Mandrill.Models;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests
{
  [TestFixture]
  internal class TemplatesTests
  {
    public static bool Validator(object sender, X509Certificate certificate, X509Chain chain,
      SslPolicyErrors sslPolicyErrors)
    {
      return true;
    }

    [TestFixtureSetUp]
    public void Init()
    {
      if (ConfigurationManager.AppSettings["IgnoreInvalidSSLCertificate"] == "True")
        ServicePointManager.ServerCertificateValidationCallback = Validator;
    }

    
    [Test]
    public void Can_Update_Template()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string templateName = ConfigurationManager.AppSettings["TemplateExample"];
      const string original = "<span mc:edit=\"model1\"></span>";
      const string modified = "<span mc:edit=\"model2\"></span>";

      // Exercise
      var api = new MandrillApi(apiKey);
      TemplateInfo result = api.UpdateTemplate(templateName,
        "test@test.invalid",
        "Test",
        "Template test",
        modified,
        "*|model1|*",
        true,
        null);
      TemplateInfo result2 = api.UpdateTemplate(templateName,
        "test@test.invalid",
        "Test",
        "Template test",
        original,
        "*|model1|*",
        true,
        null);

      // Verify
      Assert.AreEqual(modified, result.Code);
      Assert.AreEqual(original, result2.Code);
    }

    [Test]
    public void List_Templates_Returns_Correct_Count()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      int templateCount = int.Parse(ConfigurationManager.AppSettings["TemplateCount"]);

      // Exercise
      var api = new MandrillApi(apiKey);
      List<TemplateInfo> result = api.ListTemplates();

      int expected = templateCount;

      // Verify
      Assert.AreEqual(expected, result.Count);
    }

    [Test]
    public void List_Templates_With_Label_Returns_Correct_Count()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      int templateCount = int.Parse(ConfigurationManager.AppSettings["TemplateCountWithLabel"]);
      string label = ConfigurationManager.AppSettings["TemplateLabel"];

      // Exercise
      var api = new MandrillApi(apiKey);
      List<TemplateInfo> result = api.ListTemplates(label);

      int expected = templateCount;

      // Verify
      Assert.AreEqual(expected, result.Count);
    }

    [Test]
    public async Task Render_Template_Returns_Correct_Content()
    {
      // Setup
      string apiKey = ConfigurationManager.AppSettings["APIKey"];
      string templateName = ConfigurationManager.AppSettings["TemplateExample"];

      // Exercise
      var api = new MandrillApi(apiKey);
      var templateContent = new TemplateContent
      {
        Content = "Test",
        Name = "model1"
      };
      RenderedTemplate result = await api.Render(templateName, new List<TemplateContent> {templateContent}, null);

      string expected = "<span>Test</span>";

      // Verify
      Assert.AreEqual(expected, result.Html);
    }
  }
}