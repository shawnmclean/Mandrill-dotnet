// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MandrillApi.cs" company="">
//   
// </copyright>
// <summary>
//   Core class for using the MandrillApp Api
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    using System.Dynamic;
    using System.Net;
    using System.Threading.Tasks;

    using Mandrill.Utilities;

    using RestSharp;

    /// <summary>
    ///     Core class for using the MandrillApp Api
    /// </summary>
    public partial class MandrillApi
    {
        #region Fields

        /// <summary>
        ///     the main rest client for use throughout the whole app.
        /// </summary>
        private readonly RestClient client;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MandrillApi" /> class.
        /// </summary>
        /// <param name="apiKey">
        ///     The API Key recieved from MandrillApp
        /// </param>
        /// <param name="useSsl">
        /// </param>
        /// <param name="timeout">
        ///     Timeout in milliseconds to use for requests.
        /// </param>
        public MandrillApi(string apiKey, bool useSsl = true, int timeout = 0)
        {
            this.ApiKey = apiKey;

            if (useSsl)
            {
                this.client = new RestClient(Configuration.BASE_SECURE_URL);
            }
            else
            {
                this.client = new RestClient(Configuration.BASE_URL);
            }

            this.client.AddHandler("application/json", new DynamicJsonDeserializer());
            this.client.Timeout = timeout;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     The Api Key for the project received from the MandrillApp website
        /// </summary>
        public string ApiKey { get; private set; }

        public IWebProxy Proxy
        {
            get
            {
                return this.client.Proxy;
            }
            set
            {
                this.client.Proxy = value;
            }
        }

        /// <summary>
        ///     UserAgent to use for requests.
        /// </summary>
        public string UserAgent
        {
            get
            {
                return this.client.UserAgent;
            }
            set
            {
                this.client.UserAgent = value;
            }
        }

        #endregion

        // CODEPATH IS DISABLED (USES EXECUTEASYNC). EXECUTE ASYNC HAS A BUG
        // public Task<IRestResponse> PostAsync(string path, dynamic data)
        // {
        // TaskCompletionSource<IRestResponse> tcs = new TaskCompletionSource<IRestResponse>();

        // var request = new RestRequest(path, Method.POST);
        // request.RequestFormat = DataFormat.Json;

        // if (data == null)
        // {
        // data = new ExpandoObject();
        // }

        // data.key = ApiKey;

        // request.AddBody(data);
        // client.ExecuteAsync(request, (response) =>
        // {
        // if (response.StatusCode != System.Net.HttpStatusCode.OK)
        // {
        // var error = JSON.Parse<ErrorResponse>(response.Content);
        // var ex = new MandrillException(error, string.Format("Post failed {0}", path));
        // tcs.SetException(ex);
        // }
        // else
        // {
        // tcs.SetResult(response);
        // }
        // });

        // return tcs.Task;
        // }

        #region Public Methods and Operators

        /// <summary>
        ///     PostAsync (uses synchronous function right now because ExecuteAsync has a bug)
        /// </summary>
        /// <param name="path">
        /// </param>
        /// <param name="data">
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<IRestResponse> PostAsync(string path, dynamic data)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        var request = new RestRequest(path, Method.POST);
                        request.RequestFormat = DataFormat.Json;

                        if (data == null)
                        {
                            data = new ExpandoObject();
                        }

                        data.key = this.ApiKey;

                        request.AddBody(data);

                        IRestResponse response = this.client.Execute(request);

                        // if internal server error, then mandrill should return a custom error.
                        if (response.StatusCode == HttpStatusCode.InternalServerError)
                        {
                            var error = JSON.Parse<ErrorResponse>(response.Content);
                            var ex = new MandrillException(error, string.Format("Post failed {0}", path));
                            throw ex;
                        }

                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            // used to throw errors not returned from the server, such as no response, etc.
                            throw response.ErrorException;
                        }

                        return response;
                    });
        }

        /// <summary>
        ///     The post async.
        /// </summary>
        /// <param name="path">
        ///     The path.
        /// </param>
        /// <param name="data">
        ///     The data.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<T> PostAsync<T>(string path, dynamic data) where T : new()
        {
            Task<IRestResponse> post = this.PostAsync(path, data);

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