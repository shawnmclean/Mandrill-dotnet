using Mandrill.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace Mandrill.Tests.IntegrationTests.Users
{
  public class PingTests : IntegrationTestBase
  {
    [Fact]
    public async Task Should_Return_Pong_On_Valid_ApiKey()
    {
      // Setup
      var apiKey = Settings.ApiKey;

      // Exercise
      var serviceProvider = new ServiceCollection()
        .AddMandrillApi(apiKey)
        .BuildServiceProvider();

      var api = serviceProvider.GetRequiredService<IMandrillApi>();

      var result = await api.Ping();

      var expected = "PONG!";

      // Verify
      Assert.Equal(expected, result);
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
      var ex = await Assert.ThrowsAsync<MandrillException>(async () => await api.Ping());
      Assert.Equal(ex.Error.Name, "Invalid_Key");
    }
  }
}