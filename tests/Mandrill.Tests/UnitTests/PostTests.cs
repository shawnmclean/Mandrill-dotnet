using Mandrill.Requests;
using Mandrill.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RichardSzalay.MockHttp;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mandrill.Tests.UnitTests
{
  public class PostTests : IDisposable
  {
    public PostTests()
    {
      var responseMessage = new HttpResponseMessage();
      var messageHandler = new FakeHttpMessageHandler(responseMessage);
      httpClient = new HttpClient(messageHandler);
    }

    public void Dispose()
    {
      httpClient?.Dispose();
    }

    private IMandrillApi RespondWith(string path, HttpStatusCode statusCode, string content)
    {
      var httpMessageHandlerMock = new MockHttpMessageHandler();
      httpMessageHandlerMock
          .When(HttpMethod.Post, path)
          .Respond(statusCode, MediaTypeNames.Text.Plain, content);
      // Create our test DI container
      var serviceProvider = new ServiceCollection()
          // Add and configure our typed HTTP client
          .AddMandrillApi("")
          // Overwrite what you need
          .OverridePrimaryHttpMessageHandler<IMandrillApi>(httpMessageHandlerMock)
          .BuildServiceProvider();
      return serviceProvider.GetRequiredService<IMandrillApi>();
    }

    private readonly HttpClient httpClient;

    private class SampleObject
    {
      [JsonPropertyName("Name")]
      public string Name { get; set; }
      [JsonPropertyName("Id")]
      public int Id { get; set; }
    }

    private class SamplePayload : RequestBase
    {
    }

    public class FakeHttpMessageHandler : HttpMessageHandler
    {
      private readonly HttpResponseMessage response;

      public FakeHttpMessageHandler(HttpResponseMessage response)
      {
        this.response = response;
      }

      protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
      {
        var responseTask = new TaskCompletionSource<HttpResponseMessage>();
        responseTask.SetResult(response);

        return responseTask.Task;
      }
    }

    public class FakeHttpContent : HttpContent
    {
      public FakeHttpContent(string content)
      {
        Content = content;
      }

      public string Content { get; set; }

      protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
      {
        var byteArray = Encoding.ASCII.GetBytes(Content);
        await stream.WriteAsync(byteArray, 0, Content.Length).ConfigureAwait(false);
      }

      protected override bool TryComputeLength(out long length)
      {
        length = Content.Length;
        return true;
      }
    }

    [Fact]
    public async Task Should_Allow_Multiple_Requests_With_Single_HttpClient()
    {
      var responseString = @"{
     ""Name"": ""Shawn"",
     ""Id"": 1
        }";
      var api = RespondWith($"{Configuration.BASE_SECURE_URL}", HttpStatusCode.OK, responseString);
      await api.Post<SampleObject>("", new SamplePayload());
      await api.Post<SampleObject>("", new SamplePayload());
    }

    [Fact]
    public async Task Should_Serialize_Response_When_Json_Content_Is_Recieved()
    {
      var responseString = @"{
       ""Name"": ""Shawn"",
       ""Id"": 1
      }";
      var api = RespondWith($"{Configuration.BASE_SECURE_URL}", HttpStatusCode.OK, responseString);

      var response = await api.Post<SampleObject>("", new SamplePayload());

      Assert.Equal("Shawn", response.Name);
      Assert.Equal(1, response.Id);
    }

    [Fact]
    public async Task Should_Throw_Mandrill_Exception_When_Serialization_Error()
    {
      var responseString = @"<html></html>";

      var api = RespondWith($"{Configuration.BASE_SECURE_URL}", HttpStatusCode.OK, responseString);


      var ex = await Assert.ThrowsAsync<MandrillSerializationException>(async () =>
        await api.Post<object>("", new SamplePayload()));
      var content = await ex.HttpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.Equal(responseString, content);
    }

    [Fact]
    public async Task Should_Throw_Mandrill_Exception_When_Server_Error()
    {
      var responseString = @"{
       ""code"": 501,
       ""message"": ""m1"",
       ""name"": ""n1"",
       ""status"": ""s1""
      }";

      var api = RespondWith($"{Configuration.BASE_SECURE_URL}", HttpStatusCode.InternalServerError, responseString);

      var ex = await Assert.ThrowsAsync<MandrillException>(async () => await api.Post<object>("", new SamplePayload()));
      Assert.Equal(501, ex.Error.Code);
      Assert.Equal("m1", ex.Error.Message);
      Assert.Equal("n1", ex.Error.Name);
      Assert.Equal("s1", ex.Error.Status);
    }
  }
}