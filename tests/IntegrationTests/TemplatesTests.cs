﻿using System;
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

            string expected = "<!DOCTYPE html>\n<span>Test</span>";
            
            // Verify
            Assert.AreEqual(expected, result.html);
        }
    }
}
