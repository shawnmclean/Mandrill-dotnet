using System;
using System.Net.Http;

namespace Mandrill.Tests
{
  internal sealed class HttpMessageHandlerMockWrapper
  {
    public HttpMessageHandlerMockWrapper(
        Type typedHttpClientType,
        HttpMessageHandler httpMessageHandlerMock)
    {
      TypedHttpClientType = typedHttpClientType;
      HttpMessageHandlerMock = httpMessageHandlerMock;
    }

    public Type TypedHttpClientType { get; }
    public HttpMessageHandler HttpMessageHandlerMock { get; }
  }
}
