using Mandrill.Requests;
using Mandrill.Utilities;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mandrill.Tests.UnitTests
{
  [TestFixture]
  public class PostTests
  {
    [SetUp]
    public void CreateHttpTest()
    {
      var responseMessage = new HttpResponseMessage();
      var messageHandler = new FakeHttpMessageHandler(responseMessage);
      httpClient = new HttpClient(messageHandler);
    }

    [TearDown]
    public void DisposeHttpTest()
    {
      httpClient.Dispose();
    }

    private void RespondWith(MandrillApi api, HttpStatusCode statusCode, string content)
    {
      var responseMessage = new HttpResponseMessage(statusCode);
      responseMessage.Content = new FakeHttpContent(content);
      var messageHandler = new FakeHttpMessageHandler(responseMessage);
      api.SetHttpClient(new HttpClient(messageHandler));
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

    [Test]
    public async Task Should_Serialize_Response_When_Json_Content_Is_Recieved()
    {
      string responseString = @"{
	      ""Name"": ""Shawn"",
	      ""Id"": 1
      }";
      var api = new MandrillApi("");
      RespondWith(api, HttpStatusCode.OK, responseString);

      SampleObject response = await api.Post<SampleObject>("", new SamplePayload());

      Assert.AreEqual("Shawn", response.Name);
      Assert.AreEqual(1, response.Id);
    }

    [Test]
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

      var ex = Assert.Throws<MandrillException>(async () => await api.Post<object>("", new SamplePayload()));
      Assert.AreEqual(501, ex.Error.Code);
      Assert.AreEqual("m1", ex.Error.Message);
      Assert.AreEqual("n1", ex.Error.Name);
      Assert.AreEqual("s1", ex.Error.Status);
    }

    // TODO: Figure out how to Simulate a timeout using HttpClient
    //[Test]
    //public async Task Should_Throw_TimeOut_Exception_When_Timing_Out()
    //{
    //    httpClient.SimulateTimeout();

    //    var api = new MandrillApi("");

    //    Assert.Throws<TimeoutException>(async () => await api.Post<object>("", new SamplePayload()));
    //}

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

      protected async override Task SerializeToStreamAsync(Stream stream, TransportContext context)
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