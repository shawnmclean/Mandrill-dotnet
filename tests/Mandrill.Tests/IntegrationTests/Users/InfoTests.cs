using Mandrill.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace Mandrill.Tests.IntegrationTests.Users
{
  public class InfoTests : IntegrationTestBase
  {
    [Fact]
    public async Task Should_Return_Info()
    {
      // Setup
      var apiKey = Settings.ApiKey;

      var serviceProvider = new ServiceCollection()
        .AddMandrillApi(apiKey)
        .BuildServiceProvider();

      var api = serviceProvider.GetRequiredService<IMandrillApi>();

      var result = await api.UserInfo();

      // Verify
      Assert.Equal(Settings.Username, result.Username);
    }

    [Fact]
    public async Task Should_Throw_Exception_On_Invalid_ApiKey()
    {
      // Setup
      var apiKey = " ";

      // Exercise
      var serviceProvider = new ServiceCollection()
        .AddMandrillApi(apiKey)
        .BuildServiceProvider();

      var api = serviceProvider.GetRequiredService<IMandrillApi>();

      // Verify
      var ex = await Assert.ThrowsAsync<MandrillException>(async () => await api.UserInfo());
      Assert.Equal(ex.Error.Name, "Invalid_Key");
    }
  }
}