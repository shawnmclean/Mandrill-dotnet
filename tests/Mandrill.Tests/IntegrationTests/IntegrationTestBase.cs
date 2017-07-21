using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Mandrill.Tests.IntegrationTests
{
  public abstract class IntegrationTestBase
  {
    public readonly TestSettings Settings;
    protected bool IsPaidAccount;

    protected IntegrationTestBase()
    {
      var config = new ConfigurationBuilder()
        .AddJsonFile("test-settings.json")
        .AddEnvironmentVariables()
        .Build();

      var section = config.GetSection("TestSettings");
      Settings = new TestSettings();
      new ConfigureFromConfigurationOptions<TestSettings>(section).Configure(Settings);
    }

    public static bool Validator(object sender, X509Certificate certificate, X509Chain chain,
      SslPolicyErrors sslPolicyErrors)
    {
      return true;
    }
  }
}