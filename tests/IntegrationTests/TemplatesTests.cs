using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Mandrill.Tests.IntegrationTests
{
    [TestFixture]
    class TemplatesTests
    {
        public static bool Validator (object sender, X509Certificate certificate, X509Chain chain, 
                                      SslPolicyErrors sslPolicyErrors) {
            return true;
        }

        [TestFixtureSetUp]
        public void Init () {
            if (ConfigurationManager.AppSettings["IgnoreInvalidSSLCertificate"] == "True")
                ServicePointManager.ServerCertificateValidationCallback = Validator;
        }
           
        [Test]
        public void Render_Template_Returns_Correct_Content()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            var templateName = ConfigurationManager.AppSettings["TemplateExample"];
            
            // Exercise
            var api = new MandrillApi(apiKey);
            var templateContent = new TemplateContent
                                      {
                                          content = "Test",
                                          name = "model1"
                                      };
            var result = api.Render(templateName, new List<TemplateContent>{templateContent}, null);

            string expected = "<span>Test</span>";
            
            // Verify
            Assert.AreEqual(expected, result.html);
        }

        [Test]
        public void Can_Return_Individial_Template()
        {
			// Setup
			var apiKey = ConfigurationManager.AppSettings["APIKey"];
			var templateName = ConfigurationManager.AppSettings["TemplateExample"];
			
			// Exercise
			var api = new MandrillApi(apiKey);
			var result = api.TemplateInfo(templateName);
			
			var expected = "<span mc:edit=\"model1\"></span>";
			
			// Verify
			Assert.AreEqual(expected, result.code);
        }

        [Test]
        public void List_Templates_Returns_Correct_Count()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            var templateCount = int.Parse(ConfigurationManager.AppSettings["TemplateCount"]);

            // Exercise
            var api = new MandrillApi(apiKey);
            var result = api.ListTemplates();

            var expected = templateCount;

            // Verify
            Assert.AreEqual(expected, result.Count);
        }

        [Test]
        public void Can_Update_Template()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            var templateName = ConfigurationManager.AppSettings["TemplateExample"];
            const string original = "<span mc:edit=\"model1\"></span>";
            const string modified = "<span mc:edit=\"model2\"></span>";

            // Exercise
            var api = new MandrillApi(apiKey);
            var result = api.UpdateTemplate(templateName,
                "test@test.invalid",
                "Test",
                "Template test",
                modified,
                "*|model1|*",
                true,
                null);
            var result2 = api.UpdateTemplate(templateName,
                "test@test.invalid",
                "Test",
                "Template test",
                original,
                "*|model1|*",
                true,
                null);

            // Verify
            Assert.AreEqual(modified, result.code);
            Assert.AreEqual(original, result2.code);
        }

        [Test]
        public void Can_Create_And_Delete_Template()
        {
            // Setup
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            var templateName = ConfigurationManager.AppSettings["TemplateExample"] + "_temp";
            const string code = "Foobar";

            // Exercise
            var api = new MandrillApi(apiKey);
            var result = api.AddTemplate(templateName, "test@test.invalid", "Test", "Template test", code, code, true);
            var result2 = api.DeleteTemplate(templateName);

            // Verify
            Assert.AreEqual(code, result.code);
            Assert.AreEqual(code, result2.code);
        }
    }
}
