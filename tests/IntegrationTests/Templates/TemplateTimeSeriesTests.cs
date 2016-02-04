using System;
using System.Configuration;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Templates;
using NUnit.Framework;
using System.Collections.Generic;

namespace Mandrill.Tests.IntegrationTests.Templates
{
  [TestFixture]
  public class TemplateTimeSeriesTests : IntegrationTestBase
  {
    [Test]
    public async Task Should_Get_Template_Time_Series()
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

      List<TemplateTimeSeries> result = await api.TemplateTimeSeries(new TemplateTimeSeriesRequest(templateName));

      // Verify
      Assert.IsNotNull(result);

      //Time series do not exist for brand new templates. No other asserts possible.

      // Cleanup
      await api.DeleteTemplate(new DeleteTemplateRequest(templateName));
    }
  }
}