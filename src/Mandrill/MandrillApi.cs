// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MandrillApi.cs" company="">
//
// </copyright>
// <summary>
//   Core class for using the MandrillApp Api
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mandrill.Models;
using Mandrill.Requests;
using Mandrill.Utilities;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mandrill
{
  /// <summary>
  ///   Core class for using the MandrillApp Api
  /// </summary>
  public partial class MandrillApi : IDisposable, IMandrillApi
  {
    #region Fields

    private HttpClient _httpClient;

    #endregion

    #region Constructors and Destructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="MandrillApi" /> class.
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="options"></param>
    public MandrillApi(HttpClient httpClient, MandrillApiOptions options)
    {
      _httpClient = httpClient;
      ApiKey = options.ApiKey;
    }

    #endregion

    #region Private Methods and Operators

    private static T ParseResponseContent<T>(string path, RequestBase data, string content, HttpResponseMessage response)
    {
      if (response.StatusCode == HttpStatusCode.OK)
        try
        {
          return JSON.Parse<T>(content);
        }
        catch (JsonException ex)
        {
          throw new MandrillSerializationException($"Failed to deserialize content received from path: {path}.", ex)
          {
            HttpResponseMessage = response,
            MandrillRequest = data,
            Content = content
          };
        }

      try
      {
        var error = JsonSerializer.Deserialize<ErrorResponse>(content);

        throw new MandrillException(error, $"Post failed: {path}")
        {
          HttpResponseMessage = response,
          MandrillRequest = data
        };
      }
      catch (JsonException ex)
      {
        throw new MandrillSerializationException($"Failed to deserialize error content received from path: {path}.", ex)
        {
          HttpResponseMessage = response,
          MandrillRequest = data,
          Content = content
        };
      }
    }

    #endregion

    #region Public Properties

    /// <summary>
    ///   The Api Key for the project received from the MandrillApp website
    /// </summary>
    public string ApiKey { get; }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    ///   Execute post to path
    /// </summary>
    /// <param name="path">the path to post to</param>
    /// <param name="data">the payload to send in request body as json</param>
    /// <returns></returns>
    public async Task<T> Post<T>(string path, RequestBase data)
    {
      data.Key = ApiKey;
      try
      {

        string requestContent;
        try
        {
          requestContent = JSON.Serialize(data);
        }
        catch (JsonException ex)
        {
          throw new MandrillSerializationException("Failed to serialize request data.", ex);
        }

        var response =
          await
            _httpClient.PostAsync(
                path,
                new StringContent(requestContent, Encoding.UTF8, "application/json"))
              .ConfigureAwait(false);

        var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        return ParseResponseContent<T>(path, data, responseContent, response);
      }
      catch (TimeoutException ex)
      {
        throw new TimeoutException(string.Format("Post timed out to {0}", path), ex);
      }
    }

    public void Dispose()
    {
      _httpClient?.Dispose();
    }

    #endregion
  }
}