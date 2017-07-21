using Mandrill.Requests;
using Mandrill.Utilities;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
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
    public void Dispose() {
      httpClient?.Dispose();
    }

    private void RespondWith(MandrillApi api, HttpStatusCode statusCode, string content)
    {
      var responseMessage = new HttpResponseMessage(statusCode);
      responseMessage.Content = new FakeHttpContent(content);
      var messageHandler = new FakeHttpMessageHandler(responseMessage);
      var httpClient = new HttpClient(messageHandler)
      {
          BaseAddress = new Uri(Configuration.BASE_SECURE_URL)
      };
      api.SetHttpClient(httpClient);
    }

    private HttpClient httpClient;

    private class SampleObject
    {
      public string Name { get; set; }
      public int Id { get; set; }
    }

    private class SamplePayload : RequestBase
    {
    }

    [Fact]
    public async Task Should_Serialize_Response_When_Json_Content_Is_Recieved()
    {
      string responseString = @"{
	      ""Name"": ""Shawn"",
	      ""Id"": 1
      }";
      var api = new MandrillApi("");
      RespondWith(api, HttpStatusCode.OK, responseString);

      SampleObject response = await api.Post<SampleObject>("", new SamplePayload());

      Assert.Equal("Shawn", response.Name);
      Assert.Equal(1, response.Id);
    }

    [Fact]
    public async Task Should_Throw_Mandrill_Exception_When_Server_Error()
    {
      string responseString = @"{
	      ""code"": ""501"",
	      ""message"": ""m1"",
	      ""name"": ""n1"",
	      ""status"": ""s1""
      }";

      var api = new MandrillApi("");
      RespondWith(api, HttpStatusCode.InternalServerError, responseString);

      var ex = await Assert.ThrowsAsync<MandrillException>(async () => await api.Post<object>("", new SamplePayload()));
      Assert.Equal(501, ex.Error.Code);
      Assert.Equal("m1", ex.Error.Message);
      Assert.Equal("n1", ex.Error.Name);
      Assert.Equal("s1", ex.Error.Status);
    }

    [Fact]
    public async Task Should_Allow_Multiple_Requests_With_Single_HttpClient()
    {
        string responseString = @"{
	    ""Name"": ""Shawn"",
	    ""Id"": 1
        }";
        var api = new MandrillApi("");
        RespondWith(api, HttpStatusCode.OK, responseString);
        await api.Post<SampleObject>("", new SamplePayload());
        await api.Post<SampleObject>("", new SamplePayload());
    }

    [Fact]
    public async Task Should_Throw_Mandrill_Exception_When_Serialization_Error()
    {
      string responseString = @"<html></html>";

      var api = new MandrillApi("");
      RespondWith(api, HttpStatusCode.OK, responseString);

      var ex = await Assert.ThrowsAsync<MandrillSerializationException>(async () => await api.Post<object>("", new SamplePayload()));
      var content = await ex.HttpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
      Assert.Equal(responseString, content);
    }
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
      private HttpResponseMessage response;

      public FakeHttpMessageHandler(HttpResponseMessage response)
      {
        this.response = response;
      }

      protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
      {
        var responseTask = new TaskCompletionSource<HttpResponseMessage>();
        responseTask.SetResult(response);

        return responseTask.Task;
      }
    }

    public class FakeHttpContent : HttpContent
    {
      public string Content { get; set; }

      public FakeHttpContent(string content)
      {
        Content = content;
      }

      protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
      {
        byte[] byteArray = Encoding.ASCII.GetBytes(Content);
        await stream.WriteAsync(byteArray, 0, Content.Length).ConfigureAwait(false);
      }

      protected override bool TryComputeLength(out long length)
      {
        length = Content.Length;
        return true;
      }
    }

  }
}