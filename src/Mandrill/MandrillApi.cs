// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MandrillApi.cs" company="">
//   
// </copyright>
// <summary>
//   Core class for using the MandrillApp Api
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Dynamic;
using System.Net;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Mandrill.Models;
using Mandrill.Models.Requests;
using RestSharp;

namespace Mandrill
{
  /// <summary>
  ///   Core class for using the MandrillApp Api
  /// </summary>
  public partial class MandrillApi
  {
    #region Fields

    /// <summary>
    ///   the main rest client for use throughout the whole app.
    /// </summary>
    private readonly RestClient _client;

    private readonly string baseUrl;

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
    /// <param name="timeout">
    ///   Timeout in milliseconds to use for requests.
    /// </param>
    public MandrillApi(string apiKey, bool useHttps = true)
    {
      ApiKey = apiKey;

      if (useHttps)
      {
        baseUrl = Configuration.BASE_SECURE_URL;
        _client = new RestClient(Configuration.BASE_SECURE_URL);
      }
      else
      {
        baseUrl = Configuration.BASE_URL;
        _client = new RestClient(Configuration.BASE_URL);
      }

    }

    #endregion

    #region Public Properties

    /// <summary>
    ///   The Api Key for the project received from the MandrillApp website
    /// </summary>
    public string ApiKey { get; private set; }

    public IWebProxy Proxy
    {
      get { return _client.Proxy; }
      set { _client.Proxy = value; }
    }

    /// <summary>
    ///   UserAgent to use for requests.
    /// </summary>
    public string UserAgent
    {
      get { return _client.UserAgent; }
      set { _client.UserAgent = value; }
    }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    ///   The post async.
    /// </summary>
    /// <param name="path">
    ///   The path.
    /// </param>
    /// <param name="data">
    ///   The data.
    /// </param>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public Task<IRestResponse> PostAsync(string path, dynamic data)
    {
      var tcs = new TaskCompletionSource<IRestResponse>();
      var request = new RestRequest(path, Method.POST) {RequestFormat = DataFormat.Json};

      if (data == null)
      {
        data = new ExpandoObject();
      }

      data.key = ApiKey;

      request.RequestFormat = DataFormat.Json;
      request.AddBody(data);
      _client.ExecuteAsync(request, response =>
      {
        if (response.ErrorException != null)
        {
          tcs.SetException(response.ErrorException);
        }
        else if (response.ResponseStatus != ResponseStatus.Completed)
        {
          var ex =
            new MandrillException(string.Format("Post failed {0} with response status {1}", path,
              response.ResponseStatus));
          tcs.SetException(ex);
        }
        else if (response.StatusCode != HttpStatusCode.OK)
        {
          try
          {
            var error = JSON.Parse<ErrorResponse>(response.Content);
            var ex = new MandrillException(error,
              string.Format("Post failed {0} with status {1}", path, response.StatusCode));
            tcs.SetException(ex);
          }
          catch (Exception ex)
          {
            string content = response.Content ?? "";
            var mandrillException =
              new MandrillException(
                string.Format("Post failed {0} with status {1} and content '{2}'", path, response.StatusCode, content),
                ex);
            tcs.SetException(mandrillException);
          }
        }
        else
        {
          tcs.SetResult(response);
        }
      });

      return tcs.Task;
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
        T result = await Configuration.BASE_URL.AppendPathSegment(path)
          .PostJsonAsync(data).ReceiveJson<T>();

        return result;
      } catch (FlurlHttpTimeoutException ex) {
        throw new TimeoutException(string.Format("Post timed out to {0}", path));
      }
      catch (FlurlHttpException ex)
      {
        var response = ex.GetResponseJson<ErrorResponse>();
        throw new MandrillException(response, string.Format("Post failed {0} with status {1} and content '{2}'", path,
          ex.Call.HttpStatus, ex.Call.RequestBody));
      }
    }


    /// <summary>
    ///   The post async.
    /// </summary>
    /// <param name="path">
    ///   The path.
    /// </param>
    /// <param name="data">
    ///   The data.
    /// </param>
    /// <typeparam name="T">
    /// </typeparam>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    public Task<T> PostAsync<T>(string path, dynamic data) where T : new()
    {
      Task<IRestResponse> post = PostAsync(path, data);

      return post.ContinueWith(
        p =>
        {
          var t = JSON.Parse<T>(p.Result.Content);
          return t;
        },
        TaskContinuationOptions.ExecuteSynchronously);
    }

    #endregion
  }
}