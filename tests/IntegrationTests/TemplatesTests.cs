using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests
{[TestFixture]
    class TemplatesTests
    {
           
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

            string expected = "<!DOCTYPE html>\n<span>Test</span>";
            
            // Verify
            Assert.AreEqual(expected, result.html);
        }
    }
}
