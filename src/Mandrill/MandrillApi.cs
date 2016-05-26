// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MandrillApi.cs" company="">
//   
// </copyright>
// <summary>
//   Core class for using the MandrillApp Api
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests;
using Mandrill.Utilities;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Mandrill
{
  /// <summary>
  ///   Core class for using the MandrillApp Api
  /// </summary>
  public partial class MandrillApi
  {
    #region Fields

    private readonly string baseUrl;
    private HttpClient _httpClient;

    #endregion

    #region Constructors and Destructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="MandrillApi" /> class.
    /// </summary>
    /// <param name="apiKey">
    ///   The API Key recieved from MandrillApp
    /// </param>
    /// <param name="useHttps">
    /// </param>
    /// <param name="useStatic">
    /// </param>
    public MandrillApi(string apiKey, bool useHttps = true, bool useStatic = false)
    {
      ApiKey = apiKey;

      if (useHttps && useStatic)
      {
        baseUrl = Configuration.BASE_STATIC_SECURE_URL;
      }
      else if (useHttps && !useStatic)
      {
        baseUrl = Configuration.BASE_SECURE_URL;
      }
      else if (!useHttps && useStatic)
      {
        baseUrl = Configuration.BASE_STATIC_URL;
      }
      else
      {
        baseUrl = Configuration.BASE_URL;
      }
      
      // Store URL value to be used in public BaseURL property
      BaseUrl = baseUrl;
    }

    #endregion

    #region Public Properties

    /// <summary>
    ///   The Api Key for the project received from the MandrillApp website
    /// </summary>
    public string ApiKey { get; private set; }

    ///<Summary>
    /// The base URL value being used for call, useful for client logging purposes
    ///</Summary>
    public string BaseUrl { get; set; }
    
    #endregion

    #region Public Methods and Operators

    /// <summary>
    ///   Allows overriding the HttpClient which is used in Post()
    /// </summary>
    /// <param name="httpClient">the httpClient to use</param>
    public void SetHttpClient(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

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
        using (var client = _httpClient ?? new HttpClient())
        {
          client.BaseAddress = new Uri(baseUrl);

          var response =
            await
              client.PostAsync(path,
                new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"))
                .ConfigureAwait(false);
          var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
          try
          {
            if (response.IsSuccessStatusCode)
            {
              return JsonConvert.DeserializeObject<T>(content);
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(content);

            throw new MandrillException(error, string.Format("Post failed: {0}", path))
            {
              HttpResponseMessage = response,
              MandrillRequest = data
            };
          }
          catch (JsonException)
          {
            throw new MandrillException(string.Format("Serialization Error to Post: {0}", path))
            {
              HttpResponseMessage = response,
              MandrillRequest = data
            };
          }
        }
      }
      catch (TimeoutException)
      {
        throw new TimeoutException(string.Format("Post timed out to {0}", path));
      }
    }

    #endregion
  }
}
