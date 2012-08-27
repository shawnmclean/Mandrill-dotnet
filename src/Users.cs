using System.Threading.Tasks;
using RestSharp;

namespace Mandrill
{
    public partial class MandrillApi
    {
        #region Async Methods
        /// <summary>
        ///  Async version to return the information about the API-connected user
        /// </summary>
        /// <returns></returns>
        public async Task<dynamic> InfoAsyc()
        {
            return await Task.Run(() => Info());
        }

        /// <summary>
        /// Async version to validate an API key and respond to a ping
        /// </summary>
        /// <returns></returns>
        public async Task<dynamic> PingAsyc()
        {
            return await Task.Run(() => Ping());
        }

        #endregion Async Methods

        /// <summary>
        /// Return the information about the API-connected user
        /// </summary>
        /// <returns></returns>
        /// <see cref="https://mandrillapp.com/api/docs/users.html#method=info"/>
        public dynamic Info()
        {
            var request = new RestRequest("/users/info.json", Method.POST);
            request.AddParameter("key", ApiKey);
            var response = client.Execute<dynamic>(request);
            return response.Data;
        }

        /// <summary>
        /// Validate an API key and respond to a ping
        /// </summary>
        /// <returns></returns>
        public dynamic Ping()
        {
            var request = new RestRequest("/users/ping.json", Method.POST);
            request.AddParameter("key", ApiKey);
            var response = client.Execute<dynamic>(request);
            return response.Data;
        }
    }
}