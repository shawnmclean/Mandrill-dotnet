using System.Dynamic;
using System.Threading.Tasks;
using Mandrill.Utilities;
using RestSharp;

namespace Mandrill
{
    /// <summary>
    /// Core class for using the MandrillApp Api
    /// </summary>
    public partial class MandrillApi
    {
        #region Properties

        /// <summary>
        /// The Api Key for the project received from the MandrillApp website
        /// </summary>
        public string ApiKey { get; private set; }

        #endregion Properties

        #region Fields
        /// <summary>
        /// the main rest client for use throughout the whole app.
        /// </summary>
        private RestClient client;

        #endregion Fields

        /// <summary>
        ///
        /// </summary>
        /// <param name="apiKey">The API Key recieved from MandrillApp</param>
        /// <param name="useSsl"></param>
        public MandrillApi(string apiKey, bool useSsl = true)
        {
            ApiKey = apiKey;

            if (useSsl)
            {
                client = new RestClient(Configuration.BASE_SECURE_URL);
            }
            else
            {
                client = new RestClient(Configuration.BASE_URL);
            }            
            client.AddHandler("application/json", new DynamicJsonDeserializer());
        }

        // CODEPATH IS DISABLED (USES EXECUTEASYNC). EXECUTE ASYNC HAS A BUG
        //public Task<IRestResponse> PostAsync(string path, dynamic data)
        //{
        //    TaskCompletionSource<IRestResponse> tcs = new TaskCompletionSource<IRestResponse>();

        //    var request = new RestRequest(path, Method.POST);
        //    request.RequestFormat = DataFormat.Json;

        //    if (data == null)
        //    {
        //        data = new ExpandoObject();
        //    }

        //    data.key = ApiKey;

        //    request.AddBody(data);
        //    client.ExecuteAsync(request, (response) =>
        //    {
        //        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        //        {
        //            var error = JSON.Parse<ErrorResponse>(response.Content);
        //            var ex = new MandrillException(error, string.Format("Post failed {0}", path));
        //            tcs.SetException(ex);
        //        }
        //        else
        //        {
        //            tcs.SetResult(response);
        //        }
        //    });

        //    return tcs.Task;
        //}

        /// <summary>
        /// PostAsync (uses synchronous function right now because ExecuteAsync has a bug)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<IRestResponse> PostAsync(string path, dynamic data)
        {
            return Task.Factory.StartNew(() =>
            {
                var request = new RestRequest(path, Method.POST);
                request.RequestFormat = DataFormat.Json;

                if (data == null)
                {
                    data = new ExpandoObject();
                }

                data.key = ApiKey;

                request.AddBody(data);

                var response = client.Execute(request);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var error = JSON.Parse<ErrorResponse>(response.Content);
                    var ex = new MandrillException(error, string.Format("Post failed {0}", path));
                    throw ex;
                }
                else
                {
                    return response;
                }                
            });
        }

        public Task<T> PostAsync<T>(string path, dynamic data) where T : new()
        {
            Task<IRestResponse> post = PostAsync(path, data);

            return post.ContinueWith(p =>
            {
                T t = JSON.Parse<T>(p.Result.Content);
                return t;
            }, TaskContinuationOptions.ExecuteSynchronously);
        }
    }
}