using System.Threading.Tasks;
using Mandrill.Utilities;
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

      // Exercise
      var api = new MandrillApi(apiKey);
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
      var api = new MandrillApi(apiKey);

      // Verify
      var ex = await Assert.ThrowsAsync<MandrillException>(async () => await api.UserInfo());
      Assert.Equal(ex.Error.Name, "Invalid_Key");
    }
  }
}